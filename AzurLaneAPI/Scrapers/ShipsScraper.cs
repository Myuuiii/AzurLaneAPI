using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using AzurLaneClasses.Ship;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scrapers
{
	public class ShipsScraper
	{
		private const String ImageBaseUrl = "https://azurlane.koumakan.jp/";
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

		/// <summary>
		/// Retrieve information about a ship
		/// </summary>
		public static Ship GetShipBaseInfo(String url)
		{
			if (GetShipWikiUrls().Contains(url))
			{
				Ship ship = new Ship();
				String shipBaseInfoPageContents = new WebClient().DownloadString(url);
				HtmlDocument document = new HtmlDocument();
				document.LoadHtml(shipBaseInfoPageContents);

				Boolean hasNote = GetShipHasNoteState(document);

				// ? Set database id
				ship.Id = Guid.NewGuid();
				ship = GetShipId(ship, hasNote, document);
				ship = GetShipName(ship, hasNote, document);
				ship = GetShipRarityAndStars(ship, hasNote, document);
				ship = GetShipNation(ship, hasNote, document);
				ship = GetShipType(ship, hasNote, document);
				ship = GetThumbnailImage(ship, hasNote, document);
				ship = GetConstruction(ship, hasNote, document);
				
				ship = GetShipSkins(ship, url);

				return ship;
			}
			else
			{
				return null;
			}
		}

		public static Boolean GetShipHasNoteState(HtmlDocument document)
		{
			return document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]").Descendants("div").First().HasClass("hatnote");
		}

		public static Ship GetShipId(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			if (hasNote)
			{
				ship.ShipId = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[4]/table/tbody/tr[1]/td").InnerText.Replace("\n", "");
			}
			else
			{
				ship.ShipId = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[1]/td").InnerText.Replace("\n", "");
			}
			return ship;
		}

		public static Ship GetShipName(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Name = document.DocumentNode.SelectSingleNode("//*[@id=\"firstHeading\"]").InnerText;
			return ship;
		}

		public static Ship GetShipRarityAndStars(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			String[] rarityParts;
			if (hasNote)
			{
				rarityParts = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[3]/table/tbody/tr[2]/td/div").InnerHtml.Split("<br>");
			}
			else
			{
				rarityParts = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[3]/table/tbody/tr[2]/td/div").InnerHtml.Split("<br>");
			}

			ship.Rarity = rarityParts[0];
			ship.Stars = new ShipStars
			{
				Stars = rarityParts[1],
				Count = rarityParts[1].ToCharArray().Count()
			};
			return ship;
		}

		public static Ship GetShipNation(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			if (hasNote)
			{
				ship.Nation = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[4]/table/tbody/tr[2]/td/a[2]").InnerText;
			}
			else
			{
				ship.Nation = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[2]/td/a[2]").InnerText;
			}
			return ship;
		}

		public static Ship GetShipType(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			if (hasNote)
			{
				ship.Type = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[4]/table/tbody/tr[3]/td/a[2]").InnerText;
			}
			else
			{
				ship.Type = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[3]/td/a[2]").InnerText;
			}

			return ship;
		}

		public static Ship GetThumbnailImage(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			if (hasNote)
			{
				ship.ThumbnailImage = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[2]/a/img").Attributes["src"].Value;
			}
			else
			{
				ship.ThumbnailImage = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[2]/a/img").Attributes["src"].Value;
			}
			return ship;
		}

		public static Ship GetConstruction(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Construction = new ShipConstruction();
			ship.Construction.Availability = new ConstructionAvailability();
			try
			{
				if (hasNote)
				{
					ship.Construction.ConstructionTime = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[3]/table/tbody/tr[2]/td[1]/a").InnerText.Replace("\n", "");
					ship.Construction.Availability.Light = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[3]/table/tbody/tr[4]/td[1]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Heavy = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[3]/table/tbody/tr[4]/td[2]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Special = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[3]/table/tbody/tr[4]/td[3]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Limited = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[3]/table/tbody/tr[4]/td[4]").InnerText.Replace("\n", "");
				}
				else
				{
					ship.Construction.ConstructionTime = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[2]/td[1]/a").InnerText.Replace("\n", "");
					ship.Construction.Availability.Light = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[1]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Heavy = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[2]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Special = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[3]").InnerText.Replace("\n", "");
					ship.Construction.Availability.Limited = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[4]").InnerText.Replace("\n", "");
				}
			}
			catch
			{
				if (hasNote)
				{
					try
					{
						ship.Construction.ConstructionTime = ship.Construction.ConstructionTime = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[1]/div[3]/table/tbody/tr[1]/td/a").InnerText.Replace("\n", "");
					}
					catch
					{
						// Construction time was not set on the wiki page
						ship.Construction.ConstructionTime = "";
					}
				}
				else
				{
					try
					{
						ship.Construction.ConstructionTime = ship.Construction.ConstructionTime = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[3]/table/tbody/tr[1]/td/a").InnerText.Replace("\n", "");
					}
					catch
					{
						// Construction time was not set on the wiki page
						ship.Construction.ConstructionTime = "";
					}
				}
			}
			return ship;
		}

		public static Ship GetShipSkins(Ship ship, String baseUrl)
		{
			String skinsPageContent = new WebClient().DownloadString(baseUrl + "/Gallery");
			HtmlDocument document = new HtmlDocument();
			document.LoadHtml(skinsPageContent);

			HtmlNode tabberNode = document.DocumentNode.Descendants().First(n => n.HasClass("tabber"));
			ship.Skins = new List<ShipSkin>();

			foreach (var skinTab in tabberNode.ChildNodes.Where(n => n.Name == "div"))
			{
				ShipSkin skin = new ShipSkin();
				List<HtmlNode> skinImageDescendants = skinTab.Descendants("img").ToList();

				skin.Id = Guid.NewGuid();
				skin.ChibiUrl = ImageBaseUrl + skinImageDescendants[0].Attributes["src"].Value;
				skin.ImageUrl = ImageBaseUrl + skinImageDescendants[1].Attributes["src"].Value;
				skin.BackgroundUrl = ImageBaseUrl + skinImageDescendants[2].Attributes["src"].Value;

				if (skinTab.Attributes["Title"].Value == "Default")
				{
					ship.DefaultSkin = skin;
				}

				ship.Skins.Add(skin);
			}

			return ship;
		}
	}
}