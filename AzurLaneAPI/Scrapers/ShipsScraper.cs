using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scrapers
{
	public class ShipsScraper
	{
		public static List<String> GetShipWikiUrls()
		{
			List<String> urls = new List<String>();

			String shipsListPageContents = new WebClient().DownloadString("https://azurlane.koumakan.jp/List_of_Ships");

			HtmlDocument document = new HtmlDocument();
			document.LoadHtml(shipsListPageContents);

			IEnumerable<HtmlNode> tableNodes = document.DocumentNode.Descendants("table");
			List<HtmlNode> tbodyNodes = new List<HtmlNode>();


			foreach (var tableNode in tableNodes)
			{
				foreach (var tbodyNode in tableNode.Descendants("tbody"))
				{
					foreach (var trNode in tbodyNode.Descendants("tr").Skip(1))
					{
                        HtmlNode td = trNode.Descendants("td").First();
                        HtmlNode a = td.Descendants("a").First();
                        String anchorAttributeValue = a.Attributes["href"].Value;
                        urls.Add("https://azurlane.koumakan.jp" + anchorAttributeValue);
					}
				}
			}

			return urls;
		}
	}
}