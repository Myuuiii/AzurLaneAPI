using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using HtmlAgilityPack;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ClassScraper
{
	private const string ShipByTypeUrl = "https://azurlane.koumakan.jp/wiki/List_of_Ships_by_Type";

	public static async Task GetShipClassesAsync()
	{
		DataContext context = StaticData.Context;

		HtmlDocument overviewDoc = new();
		overviewDoc.LoadHtml(
			await StaticData.Client.GetStringAsync(ShipByTypeUrl));

		IEnumerable<HtmlNode> headerNodes = overviewDoc.DocumentNode.SelectNodes("//h2/span[@class='mw-headline']");

		await CreateShipTypes(headerNodes, context);
		await context.SaveChangesAsync();

		foreach (ShipType shipType in context.ShipTypes)
		{
			await Task.Delay(500); // Artificial delay to not overload the server

			DataContext scopedDbContext = new();

			HtmlDocument typeDoc = new();
			string categoryTypeNameForUrl = shipType.Name.Pluralize().Humanize().Replace(" ", "_");
			if (shipType.Name == "DDG") categoryTypeNameForUrl = "Guided-missile_destroyers";
			typeDoc.LoadHtml(
				await StaticData.Client.GetStringAsync(
					$"https://azurlane.koumakan.jp/wiki/Category:{categoryTypeNameForUrl}"));

			// div with class mw-content-text

			HtmlNode contentNode = typeDoc.DocumentNode.SelectSingleNode("//div[@id='mw-content-text']");

			// Get the description
			HtmlNode parserNode = contentNode.SelectSingleNode("//div[@class='mw-parser-output']");
			string description = parserNode.InnerText.Cleanup().Replace("Wikipedia.", string.Empty);
			shipType.Description = description;

			// UPDATE ENTRY IN DATABASE
			scopedDbContext.ShipTypes.Update(shipType);
			await scopedDbContext.SaveChangesAsync();

			// Get the subtypes
			// //div[@id='mw-subcategories']
			Console.WriteLine($"Getting subtypes for {shipType.Name}");
			HtmlNode subcategoriesParentNode = typeDoc.DocumentNode.SelectSingleNode("//div[@id='mw-subcategories']");

			if (subcategoriesParentNode == null) continue; // No subcategories

			await CreateSubcategories(subcategoriesParentNode, shipType, scopedDbContext);

			await scopedDbContext.SaveChangesAsync();
		}
	}

	/// <summary>
	///     Create subcategories for a ship type
	/// </summary>
	/// <param name="subcategoriesParentNode"></param>
	/// <param name="shipType"></param>
	/// <param name="scopedDbContext"></param>
	private static async Task CreateSubcategories(HtmlNode subcategoriesParentNode, ShipType shipType,
		DataContext scopedDbContext)
	{
		IEnumerable<HtmlNode> subcategoryNodes = subcategoriesParentNode.SelectNodes(".//ul/li/a");

		foreach (HtmlNode item in subcategoryNodes)
		{
			string subcategoryName = item.InnerText.Cleanup().Replace(" class", string.Empty);

			if (subcategoryName == "A and B") await CreateAAndBCategoryFromJointItem(shipType);

			if (await scopedDbContext.ShipTypeSubclasses.AnyAsync(x => x.Name == subcategoryName))
				continue;

			ShipTypeSubclass newSubclass = new()
			{
				Name = subcategoryName,
				Description = "",
				ShipType = shipType
			};

			scopedDbContext.ShipTypeSubclasses.Add(newSubclass);
		}
	}

	/// <summary>
	///     Fetch all the ship classes from the wiki and add them to the database if they don't exist yet
	/// </summary>
	/// <param name="headerNodes"></param>
	/// <param name="context"></param>
	private static async Task CreateShipTypes(IEnumerable<HtmlNode> headerNodes, DataContext context)
	{
		foreach (HtmlNode node in headerNodes)
		{
			string nodeText = node.InnerText.Cleanup();
			if (await context.ShipTypes.AnyAsync(x => x.Name == nodeText))
				continue;

			ShipType newType = new()
			{
				Name = nodeText,
				Description = ""
			};
			await context.ShipTypes.AddAsync(newType);
		}
	}

	/// <summary>
	///     Since the A and B class are combined on the overview page, we create a new subclass for them ourselves
	/// </summary>
	/// <param name="shipType"></param>
	private static async Task CreateAAndBCategoryFromJointItem(ShipType shipType)
	{
		DataContext scopedDbContext = new();
		if (!await scopedDbContext.ShipTypeSubclasses.AnyAsync(x => x.Name == "A"))
		{
			ShipTypeSubclass aSubclass = new()
			{
				Id = Guid.NewGuid(),
				Name = "A",
				Description = "",
				ShipTypeId = shipType.Id
			};
			await scopedDbContext.ShipTypeSubclasses.AddAsync(aSubclass);
			await scopedDbContext.SaveChangesAsync();
		}

		if (!await scopedDbContext.ShipTypeSubclasses.AnyAsync(x => x.Name == "B"))
		{
			ShipTypeSubclass aSubclass = new()
			{
				Id = Guid.NewGuid(),
				Name = "B",
				Description = "",
				ShipTypeId = shipType.Id
			};
			await scopedDbContext.ShipTypeSubclasses.AddAsync(aSubclass);
			await scopedDbContext.SaveChangesAsync();
		}
	}
}