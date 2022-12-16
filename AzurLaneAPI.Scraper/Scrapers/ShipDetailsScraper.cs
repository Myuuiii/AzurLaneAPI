using System.Text.Json;
using System.Xml.Linq;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Scraper.Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipDetailsScraper
{
	public static int[] TableLevels = { 1, 100, 120, 125 };
	public const bool SkipExisting = false;

	public const int LongestStatRow = 14;

	public static async Task<IEnumerable<Ship>> GetShipDetailsAsync(ShipLinkContainer[] shipLinkContainers)
	{
		DataContext scopedContext = new();
		List<Ship> ships = new();

		List<ShipType> shipTypes = await StaticData._context.ShipTypes.ToListAsync();
		List<ShipTypeSubclass> subclasses = await StaticData._context.ShipTypeSubclasses.ToListAsync();
		List<Faction> factions = await StaticData._context.Factions.ToListAsync();

		foreach (IEnumerable<ShipLinkContainer> containerChunk in shipLinkContainers.Chunk(10))
		{
			IEnumerable<ShipLinkContainer> linkContainers =
				containerChunk as ShipLinkContainer[] ?? containerChunk.ToArray();
			Console.WriteLine("Processing chunk containing ships: " +
			                  linkContainers.Select(x => x.Name).Aggregate((x, y) => x + ", " + y));
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
					ship = await scopedContext.Ships
						.Include(x => x.BaseStats)
						.FirstAsync(x => x.Id == shipContainer.Id);
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
							ship.FactionId = factions.FirstOrDefault(x => x.Name.Contains(data)).Id;
							break;
						case 4:
							if (scopedContext.ShipTypeSubclasses.Any(x => x.Name.Contains(data)))
								ship.SubclassId = scopedContext.ShipTypeSubclasses.First(x => x.Name.Contains(data)).Id;
							else
							{
								Console.WriteLine($"Subclass {data} not found in database.");
								ShipTypeSubclass subclass = new()
								{
									Id = Guid.NewGuid(),
									Name = data,
									Description = "",
									ShipTypeId = ship.TypeId
								};
								await scopedContext.ShipTypeSubclasses.AddAsync(subclass);
								await scopedContext.SaveChangesAsync();
								ship.SubclassId = subclass.Id;
							}

							break;
						case 5:
							// VA
							break;
						case 6:
							// Illust
							break;
					}
				}

				// Card Stats -> Table 
				// has classes "ship-stats" and  "wikitable"

				// Basic stats


				HtmlNode statsTableNode =
					doc.DocumentNode.SelectSingleNode(".//table[@class=\"ship-stats wikitable\"]");

				// Skip the first row as it is the header
				HtmlNode[] statsTableRows = statsTableNode.SelectNodes(".//tr").Skip(1).ToArray();

				// Of the TR that has LongestStatRow items, grab the 9th td's text content and convert it to the enum value (Armor)
				// This value is to be used for all stats as it does not change with level
				Enum.TryParse(statsTableRows.First(x=>x.SelectNodes(".//td").Count() == LongestStatRow).SelectNodes(".//td")[8].InnerText.Cleanup(), out Armor armor);

				// In the list of rows, there are 4 rows we need to keep, the first td contains a name, if this name is 
				// "Base" "Level 100" "Level 120" or "Level 125" we need to keep the row
				statsTableRows = statsTableRows.Where(x =>
					new[] { "Base", "Level 100", "Level 120", "Level 125" }.Contains(x.SelectNodes(".//td")[0].InnerText
						.Cleanup())).ToArray();

				for (int i = 0; i < statsTableRows.Length; i++)
				{
					string name = statsTableRows[i].SelectNodes(".//td")[0].InnerText.Cleanup();
					ShipStats stats;
					switch (i)
					{
						case 0: // Level 125
							if (scopedContext.ShipStats.Any(x => x.Id == ship.Level125StatsId))
								stats = await scopedContext.ShipStats.FirstAsync(x => x.Id == ship.Level125StatsId);
							else stats = new ShipStats();
							break;
						case 1: // Level 120
							if (scopedContext.ShipStats.Any(x => x.Id == ship.Level120StatsId))
								stats = await scopedContext.ShipStats.FirstAsync(x => x.Id == ship.Level120StatsId);
							else stats = new ShipStats();
							break;
						case 2: // Level 100
							if (scopedContext.ShipStats.Any(x => x.Id == ship.Level100StatsId))
								stats = await scopedContext.ShipStats.FirstAsync(x => x.Id == ship.Level100StatsId);
							else stats = new ShipStats();
							break;
						case 3: // Base
							if (scopedContext.ShipStats.Any(x => x.Id == ship.BaseStatsId))
								stats = await scopedContext.ShipStats.FirstAsync(x => x.Id == ship.BaseStatsId);
							else stats = new ShipStats();
							break;
						default:
							stats = new ShipStats();
							break;
					}

					stats.Armor = armor;

					IEnumerable<HtmlNode> statsTableDataNodes = statsTableRows[i].SelectNodes(".//td");
					// Store the values for each TD (converted to int) into the stats object. The TDs are in the following order 
					// Health, Firepower, Torpedo, Aviation, AntiAir, Reload, Evasion, Speed, Accuracy, Luck, AntiSub, OilConsumption
					// Remove the first element (the first TD) as it is the header
					IEnumerable<HtmlNode> tableDataNodes = statsTableDataNodes.Skip(1).ToArray();
					int modifier = 0;
					if (statsTableDataNodes.Count() >= 14) modifier = 1; 
						
					stats.Health = int.Parse(tableDataNodes.ElementAt(0).InnerText.Cleanup());
					stats.Firepower = int.Parse(tableDataNodes.ElementAt(1).InnerText.Cleanup());
					stats.Torpedo = int.Parse(tableDataNodes.ElementAt(2).InnerText.Cleanup());
					stats.Aviation = int.Parse(tableDataNodes.ElementAt(3).InnerText.Cleanup());
					stats.AntiAir = int.Parse(tableDataNodes.ElementAt(4).InnerText.Cleanup());
					stats.Reload = int.Parse(tableDataNodes.ElementAt(5).InnerText.Cleanup());
					stats.Evasion = int.Parse(tableDataNodes.ElementAt(6).InnerText.Cleanup());
					stats.Speed = int.Parse(tableDataNodes.ElementAt(7 + modifier).InnerText.Cleanup());
					stats.Accuracy = int.Parse(tableDataNodes.ElementAt(8 + modifier).InnerText.Cleanup());
					stats.Luck = int.Parse(tableDataNodes.ElementAt(9 + modifier).InnerText.Cleanup());
					stats.AntiSub = int.Parse(tableDataNodes.ElementAt(10 + modifier).InnerText.Cleanup());
					stats.OilConsumption = int.Parse(tableDataNodes.ElementAt(11 + modifier).InnerText.Cleanup());

					switch (i)
					{
						case 0:
							ship.Level125Stats = stats;
							break;
						case 1:
							ship.Level120Stats = stats;
							break;
						case 2:
							ship.Level100Stats = stats;
							break;
						case 3:
							ship.BaseStats = stats;
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
			// await Task.Delay(3000); // Longer delay to prevent spamming the server
		}

		// TODO: Depends on the subclasses and types already being scraped. 

		return ships;
	}
}