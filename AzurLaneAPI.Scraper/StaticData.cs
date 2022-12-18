using AzurLaneAPI.Domain.Data;

namespace AzurLaneAPI.Scraper;

public static class StaticData
{
	public const string UrlPrefix = "https://azurlane.koumakan.jp";
	public static readonly DataContext Context = new();
	public static readonly HttpClient Client = new();
}