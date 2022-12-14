using AzurLaneAPI.Scraper.Entities;
using AzurLaneAPI.Scraper.Scrapers;

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
		// ShipLinkContainer[] data = await ShipListScraper.GetShipList();
		// await ClassScraper.GetShipClassesAsync();
		// await ShipDetailsScraper.GetShipDetailsAsync(data);
		await FactionsScraper.ScrapeFactionsAsync();
	}
}