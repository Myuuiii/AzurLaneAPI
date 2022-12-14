using System.Text.Json;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Scraper.Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipDetailsScraper
{
	public static int[] TableLevels = { 1, 100, 120, 125 };
	public const bool SkipExisting = true;

	public static async Task<IEnumerable<Ship>> GetShipDetailsAsync(ShipLinkContainer[] shipLinkContainers)
	{
		DataContext scopedContext = new();
		List<Ship> ships = new();

		List<ShipType> shipTypes = await StaticData._context.ShipTypes.ToListAsync();
		List<ShipTypeSubclass> subclasses = await StaticData._context.ShipTypeSubclasses.ToListAsync();
		List<Faction> factions = await StaticData._context.Factions.ToListAsync();

		foreach (IEnumerable<ShipLinkContainer> containerChunk in shipLinkContainers.Chunk(10))
		{
			IEnumerable<ShipLinkContainer> linkContainers = containerChunk as ShipLinkContainer[] ?? containerChunk.ToArray();
			Console.WriteLine("Processing chunk containing ships: " + linkContainers.Select(x=>x.Name).Aggregate((x,y)=>x + ", " + y));
			foreach (ShipLinkContainer shipContainer in linkContainers)
			{
				bool shipWithIdExists = await scopedContext.Ships.AnyAsync(s => s.Id == shipContainer.Id);
				if (SkipExisting && shipWithIdExists)
				{
					Console.WriteLine($"Skipping {shipContainer.Name} as it already exists in the database.");
					continue;
				}
				Ship ship;
				if (shipWithIdExists)
					ship = await scopedContext.Ships.FindAsync(shipContainer.Id);
				else
					ship = new Ship();
				
				HtmlDocument doc = await shipContainer.RequestDocumentAsync();

				

				Console.WriteLine("--- NOW PROCESSING ---");
				Console.WriteLine($"Name: {shipContainer.Name}");
				Console.WriteLine($"Id: {shipContainer.Id}");
				Console.WriteLine("--- --- --- --- --- ---");

				ship.Id = shipContainer.Id;

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
					string data = item.Descendants().First().InnerText.Cleanup();
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
							ship.TypeId = shipTypes.FirstOrDefault(x => x.Name.Contains(data)).Id;
							break;
						case 3:
							ship.FactionId =
								factions.FirstOrDefault(x => x.Name.Contains(data)).Id; // TODO: Scrape Factions
							break;
						case 4:
							ship.SubclassId = subclasses.FirstOrDefault(x => x.Name.Contains(data)).Id;
							break;
						case 5:
							// VA
							break;
						case 6:
							// Illust
							break;
					}
				}

				if (!shipWithIdExists)
					await scopedContext.Ships.AddAsync(ship);
				else
					scopedContext.Ships.Update(ship);
				await scopedContext.SaveChangesAsync();
				
				Console.WriteLine("Success! Delaying next request by 1 second");
				await Task.Delay(1000); // 1 second delay to prevent spamming the server
			}
			
			Console.WriteLine("Chunk Success! Delaying next chunk by 3 seconds");
			await Task.Delay(3000); // Longer delay to prevent spamming the server
		}

		// TODO: Depends on the subclasses and types already being scraped. 

		return ships;
	}
}