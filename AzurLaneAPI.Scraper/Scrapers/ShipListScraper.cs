using AzurLaneAPI.Scraper.Entities;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipListScraper
{
	/// <summary>
	///     Retrieve all the ids, names and urls for the ships (retrofit table excluded)
	/// </summary>
	/// <returns><see cref="ShipLinkContainer[]" /> or null if no body nodes were found in the document</returns>
	public static async Task<ShipLinkContainer[]> GetShipList()
	{
		HtmlDocument doc = new();
		doc.LoadHtml(await StaticData.Client.GetStringAsync(
			"https://azurlane.koumakan.jp/w/index.php?title=List_of_Ships&mobileaction=toggle_view_desktop"));

		// Retrieve all the table body nodes of the tables that contain ships
		HtmlNodeCollection? tableBodyNodes = doc.DocumentNode.SelectNodes("//table[@class='wikitable sortable']/tbody");
		if (tableBodyNodes.Count == 0)
			return null;

		// List that will be returned containing all the sets of ship ids, names and urls
		List<ShipLinkContainer> linkContainers = new();

		HandleBodyNodes(tableBodyNodes, linkContainers);

		return linkContainers.ToArray();
	}

	/// <summary>
	///     Loop over all the table body nodes and retrieve the ship ids, names and urls from each row in them
	/// </summary>
	/// <param name="tableBodyNodes">Table Body Rows</param>
	/// <param name="linkContainers"></param>
	private static void HandleBodyNodes(HtmlNodeCollection tableBodyNodes,
		ICollection<ShipLinkContainer> linkContainers)
	{
		foreach (HtmlNode tableBodyNode in tableBodyNodes)
		{
			// Get all rows in the table body, ignoring the first row as it contains the table headers
			ICollection<HtmlNode> rowNodes =
				tableBodyNode.ChildNodes.Where(n => n.OriginalName == "tr").Skip(1).ToList();

			// Loop over all the rows and retrieve the ship ids, names and urls
			foreach (HtmlNode rowNode in rowNodes)
				GetDataFromRow(rowNode, linkContainers);
		}
	}

	/// <summary>
	///     Retrieve the ship id, name and url from a row node
	/// </summary>
	/// <param name="rowNode"></param>
	/// <param name="linkContainers"></param>
	/// <returns></returns>
	private static void GetDataFromRow(HtmlNode rowNode, ICollection<ShipLinkContainer> linkContainers)
	{
		ShipLinkContainer linkContainer = new()
		{
			// Select the 1st TD element in the row, of which the text content is the ship id
			Id = rowNode.ChildNodes.First(n => n.OriginalName == "td").InnerText,
			// Select the 2nd TD element in the row, of which the text content is the ship name
			Name = rowNode.ChildNodes.Where(n => n.OriginalName == "td").Skip(1).First().InnerText
		};

		// Select the first anchor element in the 2nd TD of the row
		HtmlNode anchorNode = rowNode.ChildNodes
			.Where(n => n.OriginalName == "td")
			.Skip(1).First().ChildNodes
			.First(n => n.OriginalName == "a");

		// Get the href attribute of the anchor element
		linkContainer.Url = StaticData.UrlPrefix + anchorNode.Attributes["href"].Value;
		linkContainers.Add(linkContainer);
	}
}