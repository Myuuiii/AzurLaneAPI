using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Scraper.Scrapers;

public class FactionsScraper
{
	public static async Task ScrapeFactionsAsync()
	{
		DataContext scopedContext = new();
		HtmlDocument doc = new();
		doc.LoadHtml(await StaticData.Client.GetStringAsync("https://azurlane.koumakan.jp/wiki/Nations"));

		// Find the tables (thye all have the azltable class)
		HtmlNodeCollection? tableBodies = doc.DocumentNode.SelectNodes("//table[@class='azltable']/tbody");

		foreach (HtmlNode? node in tableBodies)
		{
			// Get all rows but skip the first since it contains the headers
			IEnumerable<HtmlNode> rows = node.SelectNodes("tr").Skip(1);

			foreach (HtmlNode row in rows)
			{
				HtmlNode[] cells = row.SelectNodes("td").ToArray();

				if (await scopedContext.Factions.AnyAsync(x => x.Name == cells[0].InnerText.Cleanup()))
				{
					Faction existingFaction = await scopedContext.Factions.FirstAsync(x => x.Name == cells[0].InnerText.Cleanup());
					existingFaction.Name = cells[0].InnerText.Cleanup();
					existingFaction.Prefix = cells[1].InnerText.Cleanup();
					existingFaction.Description = string.Empty; // TODO: Fetch this later
					existingFaction.IconUrl =
						cells.Last().Descendants().First(x => x.Name == "img").Attributes["src"].Value;
					scopedContext.Update(existingFaction);
				}
				else
				{
					Faction faction = new()
					{
						Name = cells[0].InnerText.Cleanup(),
						Prefix = cells[1].InnerText.Cleanup(),
						Description = string.Empty, // TODO: Fetch this later
						IconUrl = cells.Last().Descendants().First(x => x.Name == "img").Attributes["src"].Value
					};
					await scopedContext.Factions.AddAsync(faction);
				}
			}
		}

		if (!await scopedContext.Factions.AnyAsync(x => x.Name == "Universal"))
		{
			Faction universalFaction = new()
			{
				Name = "Universal",
				Prefix = "UNIV",
				Description = string.Empty,
				IconUrl = "https://azurlane.netojuu.com/images/thumb/d/da/Cm_1.png/145px-Cm_1.png"
			};
			await scopedContext.Factions.AddAsync(universalFaction);
		}

		await scopedContext.SaveChangesAsync();
	}
}