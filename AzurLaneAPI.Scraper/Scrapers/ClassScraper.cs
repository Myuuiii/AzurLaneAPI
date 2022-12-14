using System.Diagnostics;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using HtmlAgilityPack;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public class ClassScraper
{
	public static async Task GetShipClassesAsync()
	{
		DataContext context = StaticData._context;

		HtmlDocument overviewDoc = new();
		overviewDoc.LoadHtml(
			await StaticData.Client.GetStringAsync("https://azurlane.koumakan.jp/wiki/List_of_Ships_by_Type"));

		IEnumerable<HtmlNode> headerNodes = overviewDoc.DocumentNode.SelectNodes("//h2/span[@class='mw-headline']");

		foreach (HtmlNode node in headerNodes)
		{
			string nodeText = node.InnerText.Cleanup();
			if (await context.ShipTypes.AnyAsync(x => x.Name == nodeText))
				continue;

			ShipType newType = new()
			{
				Name = nodeText,
				Description = "", // TODO: Fetch this later
			};
			await context.ShipTypes.AddAsync(newType);
		}

		await context.SaveChangesAsync();

		foreach (ShipType shipType in context.ShipTypes)
		{
			await Task.Delay(2000); // Artificial delay to not overload the server
			
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
			
			// Get all ul/li/a elements (subcategories)
			IEnumerable<HtmlNode> subcategoryNodes = subcategoriesParentNode.SelectNodes(".//ul/li/a");
			
			foreach (HtmlNode item in subcategoryNodes)
			{
				string subcategoryName = item.InnerText.Cleanup().Replace(" class", string.Empty);

				if (subcategoryName == "A and B")
				{
					await CreateAandBCategoryFromJointItem(shipType);
					continue;
				}

				if (await scopedDbContext.ShipTypeSubclasses.AnyAsync(x => x.Name == subcategoryName))
					continue;

				ShipTypeSubclass newSubclass = new()
				{
					Name = subcategoryName,
					Description = "", // TODO: Fetch this later
					ShipType = shipType
				};

				scopedDbContext.ShipTypeSubclasses.Add(newSubclass);
			}

			await scopedDbContext.SaveChangesAsync();
		}
	}

	private static async Task CreateAandBCategoryFromJointItem(ShipType shipType)
	{
		DataContext scopedDbContext = new();
		if (!await scopedDbContext.ShipTypeSubclasses.AnyAsync(x => x.Name == "A"))
		{
			ShipTypeSubclass aSubclass = new()
			{
				Id = Guid.NewGuid(),
				Name = "A",
				Description = "", // TODO: Fetch this later
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
				Description = "", // TODO: Fetch this later
				ShipTypeId = shipType.Id
			};
			await scopedDbContext.ShipTypeSubclasses.AddAsync(aSubclass);
			await scopedDbContext.SaveChangesAsync();
		}
	}
}