using System.Text.Json;

namespace AzurLaneAPI.Scraper;

public static class ScraperEntry
{
	/// <summary>
	///     Temporary console project entry point. When the scraper is done it will be converted to a library and this will be
	///     removed.
	/// </summary>
	/// <param name="args">Console arguments</param>
	public static async Task Main(string[] args)
	{
		await ScrapeShips();
	}

	public static async Task ScrapeShips()
	{
		Console.WriteLine(JsonSerializer.Serialize(await ShipListScraper.GetShipList()));
	}
}