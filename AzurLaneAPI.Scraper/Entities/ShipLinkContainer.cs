using HtmlAgilityPack;

namespace AzurLaneAPI.Scraper.Entities;

public class ShipLinkContainer
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string Url { get; set; }

	public async Task<HtmlDocument> RequestDocumentAsync()
	{
		HtmlDocument doc = new();
		doc.LoadHtml(await StaticData.Client.GetStringAsync(Url));
		return doc;
	}
}