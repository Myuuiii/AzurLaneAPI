using AzurLaneAPI.Domain.Entities;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipDetailsScraper
{
	public static async Task<IEnumerable<Ship>> GetShipDetailsAsync()
	{
		HtmlDocument doc = new();
		doc.LoadHtml(
			await StaticData.Client.GetStringAsync("https://azurlane.koumakan.jp/wiki/List_of_Ships_by_Stats"));

		// Select all divs within a certain group idk but we need to skip 2 because the first 2 are headers and legends.
		IEnumerable<HtmlNode> tableBodyNodes =
			doc.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div[1]/div").Skip(2);

		Console.WriteLine(tableBodyNodes.Count());

		List<Ship> ships = new();
		return ships;
	}
}