using AzurLaneAPI.Domain.Data;

namespace AzurLaneAPI.Scraper;

public static class StaticData
{
	public static readonly DataContext _context = new();
	public static readonly HttpClient Client = new();
	public const string UrlPrefix = "https://azurlane.koumakan.jp";
}