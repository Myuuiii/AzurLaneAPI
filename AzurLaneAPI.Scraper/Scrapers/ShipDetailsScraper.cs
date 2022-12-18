using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Enums;
using AzurLaneAPI.Scraper.Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public static class ShipDetailsScraper
{
	private const int LongestStatRow = 14;
	private static readonly bool SkipExisting = false;
	private static readonly string[] TableRowTitles = { "Base", "Level 100", "Level 120", "Level 125" };

	public static async Task<IEnumerable<Ship>> GetShipDetailsAsync(IEnumerable<ShipLinkContainer> shipLinkContainers)
	{
		DataContext scopedContext = new();
		List<Ship> ships = new();

		shipLinkContainers = new[] // Quickly test a single ship
		{
			new ShipLinkContainer
			{
				Id = "338",
				Name = "Jintsuu",
				Url = "https://azurlane.koumakan.jp/wiki/Jintsuu"
			}
		};

		List<ShipType> shipTypes = await StaticData.Context.ShipTypes.ToListAsync();
		List<ShipTypeSubclass> subclasses = await StaticData.Context.ShipTypeSubclasses.ToListAsync();
		List<Faction> factions = await StaticData.Context.Factions.ToListAsync();

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

				// Load the HTML Document from the ship
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

				GetShipNamesFromNode(shipCardContentNode, ship);
				await LoadShipCardInfo(shipCardContentNode, ship, shipTypes, factions, subclasses, scopedContext);
				await GetShipStatistics(doc, scopedContext, ship);
				GetShipThumbnailImage(shipCardNode, ship);

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

		return ships;
	}

	/// <summary>
	///     Fetch ship statistics for the base levels
	/// </summary>
	/// <param name="doc"></param>
	/// <param name="scopedContext"></param>
	/// <param name="ship"></param>
	private static async Task GetShipStatistics(HtmlDocument doc, DataContext scopedContext, Ship ship)
	{
		// Card Stats -> Table 
		HtmlNode statsTableNode =
			doc.DocumentNode.SelectSingleNode(".//table[@class=\"ship-stats wikitable\"]");

		// Skip the first row as it is the header
		HtmlNode[] statsTableRows = statsTableNode.SelectNodes(".//tr").Skip(1).ToArray();

		// Of the TR that has LongestStatRow items, grab the 9th td's text content and convert it to the enum value (Armor)
		// This value is to be used for all stats as it does not change with level
		Enum.TryParse(
			statsTableRows.First(x => x.SelectNodes(".//td").Count == LongestStatRow).SelectNodes(".//td")[8]
				.InnerText.Cleanup(), out Armor armor);

		// In the list of rows, there are 4 rows we need to keep, the first td contains a name, if this name is 
		// "Base" "Level 100" "Level 120" or "Level 125" we need to keep the row
		statsTableRows = statsTableRows.Where(x =>
			TableRowTitles.Contains(x.SelectNodes(".//td")[0].InnerText
				.Cleanup())).ToArray();

		for (int i = 0; i < statsTableRows.Length; i++)
		{
			// Retrieve the existing entry from the database or create a new one
			ShipStats stats = await GetExistingOrNewShipStats(scopedContext, ship, i);

			stats.Armor = armor;

			IEnumerable<HtmlNode> statsTableDataNodes = statsTableRows[i].SelectNodes(".//td");
			// Store the values for each TD (converted to int) into the stats object. The TDs are in the following order 
			// Health, Firepower, Torpedo, Aviation, AntiAir, Reload, Evasion, Speed, Accuracy, Luck, AntiSub, OilConsumption
			// Remove the first element (the first TD) as it is the header
			IEnumerable<HtmlNode> tableDataNodes = statsTableDataNodes.Skip(1).ToArray();
			int tableItemOffsetModifier = 0;
			if (statsTableDataNodes.Count() >= 14) tableItemOffsetModifier = 1;

			stats.Health = GetStatIntValueOrDefault(tableDataNodes, 0);
			stats.Firepower = GetStatIntValueOrDefault(tableDataNodes, 1);
			stats.Torpedo = GetStatIntValueOrDefault(tableDataNodes, 2);
			stats.Aviation = GetStatIntValueOrDefault(tableDataNodes, 3);
			stats.AntiAir = GetStatIntValueOrDefault(tableDataNodes, 4);
			stats.Reload = GetStatIntValueOrDefault(tableDataNodes, 5);
			stats.Evasion = GetStatIntValueOrDefault(tableDataNodes, 6);
			stats.Speed = GetStatIntValueOrDefault(tableDataNodes, 7 + tableItemOffsetModifier);
			stats.Accuracy = GetStatIntValueOrDefault(tableDataNodes, 8 + tableItemOffsetModifier);
			stats.Luck = GetStatIntValueOrDefault(tableDataNodes, 9 + tableItemOffsetModifier);
			stats.AntiSub = GetStatIntValueOrDefault(tableDataNodes, 10 + tableItemOffsetModifier);
			stats.OilConsumption = GetStatIntValueOrDefault(tableDataNodes, 11 + tableItemOffsetModifier);

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
	}

	private static async Task<ShipStats> GetExistingOrNewShipStats(DataContext scopedContext, Ship ship, int i)
	{
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

		return stats;
	}

	/// <summary>
	///     Uses the ship card content node to retrieve the ship's English, Chinese and Japanese name.
	/// </summary>
	/// <param name="shipCardContentNode"></param>
	/// <param name="ship"></param>
	private static void GetShipNamesFromNode(HtmlNode shipCardContentNode, Ship ship)
	{
		HtmlNode cardHeadingNode = shipCardContentNode.SelectSingleNode(".//div[@class=\"card-headline\"]");
		HtmlNode[] cardHeadingNodes = cardHeadingNode.ChildNodes.Where(x => x.OriginalName == "span").ToArray();
		ship.EnglishName = string.Join(' ', cardHeadingNodes[0].InnerText.Cleanup().Split(" ").Skip(1));
		ship.ChineseName = cardHeadingNodes[1].InnerText.Cleanup().Replace("CN: ", "");
		ship.JapaneseName = cardHeadingNodes[2].InnerText.Cleanup().Replace("JP: ", "");
	}

	/// <summary>
	///     Load Ship information that is stored in the main ship card. This includes rarity, type, faction and subclass
	/// </summary>
	/// <param name="shipCardContentNode"></param>
	/// <param name="ship"></param>
	/// <param name="shipTypes"></param>
	/// <param name="factions"></param>
	/// <param name="subclasses"></param>
	/// <param name="scopedContext"></param>
	private static async Task LoadShipCardInfo(HtmlNode shipCardContentNode, Ship ship,
		IReadOnlyCollection<ShipType> shipTypes,
		IReadOnlyCollection<Faction> factions,
		IReadOnlyCollection<ShipTypeSubclass> subclasses, DataContext scopedContext)
	{
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
					ship.TypeId = shipTypes.First(x => x.Name.Contains(data)).Id;
					break;
				case 3:
					if (shipTypes.Any(x => x.Name.Contains(data)))
						ship.FactionId = factions.First(x => x.Name.Contains(data)).Id;
					break;
				case 4:
					if (subclasses.Any(x => x.Name.Contains(data)))
					{
						ship.SubclassId = subclasses.First(x => x.Name.Contains(data)).Id;
					}
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
					// Illustrator
					break;
			}
		}
	}

	/// <summary>
	///     Get the integer value of a node, if the node is empty, 0 will be returned
	/// </summary>
	/// <param name="nodes"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	private static int GetStatIntValueOrDefault(IEnumerable<HtmlNode> nodes, int index)
	{
		HtmlNode[] htmlNodes = nodes as HtmlNode[] ?? nodes.ToArray();
		if (htmlNodes.Length <= index) return 0;
		string value = htmlNodes.ElementAt(index).InnerText.Cleanup();
		return int.TryParse(value, out int result)
			? result
			: 0;
	}

	/// <summary>
	///     Get the ship's thumbnail image from the ship card node
	/// </summary>
	/// <param name="shipCardNode"></param>
	/// <param name="ship"></param>
	private static void GetShipThumbnailImage(HtmlNode shipCardNode, Ship ship)
	{
		// select the first image node you can find from the shipcard div
		HtmlNode shipCardImageNode = shipCardNode.SelectNodes(".//img").First();
		// get the src attribute
		string shipCardImageSrc = shipCardImageNode.Attributes["src"].Value;
		ship.ThumbnailImageUrl = shipCardImageSrc;
	}
}