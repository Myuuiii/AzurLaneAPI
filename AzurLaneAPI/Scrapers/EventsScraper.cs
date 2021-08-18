using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AzurLaneClasses;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scrapers
{
	public class EventsScraper
	{
		private const String BaseUrl = "https://azurlane.koumakan.jp";

		public static List<ALEvent> GetEvents()
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(new WebClient().DownloadString("https://azurlane.koumakan.jp/Events"));

			List<ALEvent> events = new List<ALEvent>();

			HtmlNode EventListNode = doc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/table");

			int itemId = 1;
			foreach (HtmlNode eventNode in EventListNode.Descendants("tr").Skip(1))
			{
				ALEvent eventItem = new ALEvent();
				eventItem.Id = itemId;

				// Event Name
				eventItem.Name = eventNode.Descendants("td").First().InnerText.Replace("\n", "");

				// Event dates
				if (eventNode.Descendants("td").Skip(1).First().Attributes["colspan"] == null)
				{
					eventItem.JP_Period = eventNode.Descendants("td").Skip(1).First().InnerText;
					if (eventNode.Descendants("td").Skip(2).First().Attributes["colspan"] == null)
					{
						eventItem.CN_Period = eventNode.Descendants("td").Skip(2).First().InnerText;
						eventItem.EN_Period = eventNode.Descendants("td").Skip(3).First().InnerText;
					}
					else
					{
						eventItem.CN_Period = eventItem.EN_Period = eventNode.Descendants("td").Skip(2).First().InnerText;
					}
				}
				else
				{
					switch (eventNode.Descendants("td").Skip(1).First().Attributes["colspan"].Value)
					{

						case "2":
							eventItem.JP_Period = eventItem.CN_Period = eventNode.Descendants("td").Skip(1).First().InnerText;
							eventItem.EN_Period = eventNode.Descendants("td").Skip(2).First().InnerText;
							break;
						case "3":
							eventItem.JP_Period = eventItem.CN_Period = eventItem.EN_Period = eventNode.Descendants("td").Skip(1).First().InnerText;
							break;
					}
				}

				// Event note
				eventItem.Notes = eventNode.Descendants("td").Last().InnerText;
				eventItem.IsLimited = true;
				events.Add(eventItem);
				itemId++;
			}

			HtmlNode permanentEventsListNode = doc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/p[3]");
			foreach (HtmlNode permaEventNode in permanentEventsListNode.Descendants("a"))
			{
				ALEvent eventItem = new ALEvent();
				eventItem.Id = itemId + 10000;
				eventItem.Name = permaEventNode.Attributes["title"].Value;
				eventItem.BannerUrl = BaseUrl + permaEventNode.Descendants("img").First().Attributes["src"].Value;
				events.Add(eventItem);
				itemId++;
			}

			return events;
		}
	}
}