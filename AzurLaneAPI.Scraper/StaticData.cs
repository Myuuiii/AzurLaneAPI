using AzurLaneAPI.Domain.Data;

namespace AzurLaneAPI.Scraper;

public class StaticData
{
	public static DataContext _context = new();
	public static readonly HttpClient Client = new();
	public static string UrlPrefix = "https://azurlane.koumakan.jp";
}