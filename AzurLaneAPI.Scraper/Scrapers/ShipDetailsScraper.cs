using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Scraper.Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipDetailsScraper
{
	public static int[] TableLevels = { 1, 100, 120, 125 };

	public static async Task<IEnumerable<Ship>> GetShipDetailsAsync(ShipLinkContainer[] shipLinkContainers)
	{
		List<Ship> ships = new();

		List<ShipType> shipTypes = await StaticData._context.ShipTypes.ToListAsync();
		List<ShipTypeSubclass> subclasses = await StaticData._context.ShipTypeSubclasses.ToListAsync();

		foreach (ShipLinkContainer shipContainer in shipLinkContainers)
		{
			HtmlDocument doc = await shipContainer.RequestDocumentAsync();
			Ship ship = new Ship();

			// Select the first div element on the page that has the class "ship-card"
			HtmlNode shipCardNode = doc.DocumentNode.Descendants().FirstOrDefault(x => x.HasClass("ship-card"));

			// Select fist child that has the class "ship-card-content"
			HtmlNode shipCardContentNode = shipCardNode.SelectSingleNode(".//div[@class=\"ship-card-content\"]");

			// Card Headline (containing English, Japanese and Chinese name of ship) -> // TODO: Test for all ships
			HtmlNode cardHeadingNode = shipCardContentNode.SelectSingleNode(".//div[@class=\"card-headline\"]");
			HtmlNode[] cardHeadingNodes = cardHeadingNode.ChildNodes.Where(x => x.OriginalName == "span").ToArray();
			ship.EnglishName = string.Join(' ', cardHeadingNodes[0].InnerText.Cleanup().Split(" ").Skip(1));
			ship.ChineseName = cardHeadingNodes[1].InnerText.Cleanup().Replace("CN: ", "");
			ship.JapaneseName = cardHeadingNodes[2].InnerText.Cleanup().Replace("JP: ", "");

			// Card Info -> Table // TODO: Contains 7 rows (Construction, Rarity, Classification, Faction, Subclass, VA, Illustrator)
			HtmlNodeCollection? dataNodes =
				shipCardContentNode.SelectNodes(".//div[@class=\"card-info\"]/table/tbody/tr/td[last()]");

			for (int index = 0; index < dataNodes.Count; index++)
			{
				HtmlNode? item = dataNodes[index];
				string data = item.InnerText.Cleanup();
				switch (index)
				{
					case 0:
						ship.ConstructionTime = data;
						break;
					case 1:
						Enum.TryParse(data.Split(' ')[0], out Rarity rarity);
						ship.Rarity = rarity;
						break;
					case 2:
						ship.Type = shipTypes.FirstOrDefault(x => x.Name.Contains(data));
						break;
					case 3:
						ship.Subclass = subclasses.FirstOrDefault(x => x.Name.Contains(data));
						break;
					case 4:
						// Voice actor
						break;
					case 5:
						// Illustrator
						break;
				}
			}
		}
		
		// TODO: Depends on the subclasses and types already being scraped. 

		return ships;
	}
}