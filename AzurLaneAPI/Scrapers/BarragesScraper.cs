using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AzurLaneClasses;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scrapers
{
	public class BarragesScraper
	{
		private const String BaseUrl = "https://azurlane.koumakan.jp";

		public static List<Barrage> GetBarrages()
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(new WebClient().DownloadString("https://azurlane.koumakan.jp/Barrage"));

			List<Barrage> barrages = new List<Barrage>();
			HtmlNode[] tableNodes = doc.DocumentNode.Descendants("table").ToArray();

			HtmlNode[] barrageTypeNodes = doc.DocumentNode.Descendants("h2").Skip(2).Take(3).ToArray();
			int barrageTypeLevelIndicator = 0;

			foreach (HtmlNode tableNode in tableNodes)
			{
				HtmlNode[] tableNodeRows = tableNode.Descendants("tr").Skip(1).ToArray();
				foreach (HtmlNode tableNodeRow in tableNodeRows)
				{
					HtmlNode[] tableNodeRowEntries = tableNodeRow.Descendants("td").ToArray();

					Barrage barrage = new Barrage();

					if (tableNodeRowEntries.Length == 5)
					{
						Barrage targetBarrage = barrages.Last();
						targetBarrage.Rounds.Add(new Round(
							tableNodeRowEntries[0].InnerText.Replace("\n", ""),
							Convert.ToDouble(tableNodeRowEntries[1].InnerText.Replace("\n", "")),
							Convert.ToDouble(tableNodeRowEntries[2].InnerText.Replace("\n", "")),
							Convert.ToDouble(tableNodeRowEntries[3].InnerText.Replace("\n", "")),
							tableNodeRowEntries[4].InnerText.Replace("\n", "")
						));
					}
					else
					{
						barrage.Id = tableNodeRow.Attributes["id"].Value;
						if (tableNodeRowEntries[0].ChildNodes.Any(n => n.OriginalName == "img"))
						{
							barrage.IconUrl = BaseUrl + tableNodeRowEntries[0].ChildNodes.First(n => n.OriginalName == "img").Attributes["src"].Value;
						}

						barrage.Name = tableNodeRowEntries[1].InnerText.Replace("\n", "");
						barrage.Type = barrageTypeNodes[barrageTypeLevelIndicator].InnerText.Replace(" barrages", "");

						HtmlNode[] anchors = tableNodeRowEntries[2].Descendants("a").ToArray();
						if (anchors.Length != 0)
						{
							barrage.ImageUrl = BaseUrl + anchors[0].Attributes["href"].Value;
						}

						barrage.Ships = tableNodeRowEntries[3].InnerText.Replace("\n", "").Split(", ");
						barrage.Hull = tableNodeRowEntries[4].InnerText.Replace("\n", "");

						barrage.Rounds = new List<Round>();
						barrage.Rounds.Add(new Round(
							tableNodeRowEntries[5].InnerText.Replace("\n", ""),
							Convert.ToDouble(tableNodeRowEntries[6].InnerText.Replace("\n", "")),
							Convert.ToDouble(tableNodeRowEntries[7].InnerText.Replace("\n", "")),
							Convert.ToDouble(tableNodeRowEntries[8].InnerText.Replace("\n", "")),
							tableNodeRowEntries[9].InnerText.Replace("\n", "")));

						barrages.Add(barrage);
					}
				}
                barrageTypeLevelIndicator++;
			}

			return barrages;
		}
	}
}