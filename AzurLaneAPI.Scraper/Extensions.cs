namespace AzurLaneAPI.Scraper;

public static class Extensions
{
	public static string Cleanup(this string input) =>
		input.Replace("\n", "").Replace("\t", "").Replace("Play ", "").Trim();
}