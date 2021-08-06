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

		/// <summary>
		/// Get all the wiki urls for all the ships
		/// </summary>
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
		public static Ship GetShip(String url)
		{
			if (GetShipWikiUrls().Contains(url))
			{
				Console.WriteLine($"Processing URL: {url}");

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

				ship = GetShipSkins(ship, url); /* Very Resource Heavy */
				ship = GetShipGallery(ship, url);

				// ! not finished
				// ship = GetShipSkills(ship, hasNote, document);
				// ship = GetShipLimitBreaks(ship, hasNote, document);
				// ship = GetShipEquippableSlots(ship, hasNote, document);
				// ship = GetShipStatistics(ship, hasNote, document);
				// ship = GetShipEnhanceValue(ship, hasNote, document);
				// ship = GetShipScrapValue(ship, hasNote, document);
				// ship = GetShipConstruction(ship, hasNote, document);
				ship = GetShipMiscInfo(ship, hasNote, document);

				return ship;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Get wether the main ship page has a note which could switch around some Xpaths later on
		/// </summary>
		public static Boolean GetShipHasNoteState(HtmlDocument document)
		{
			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]").Descendants("div").First().HasClass("hatnote");
		}

		/// <summary>
		/// Get the id of a ship
		/// </summary>
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the name of a ship
		/// </summary>
		public static Ship GetShipName(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Name = document.DocumentNode.SelectSingleNode("//*[@id=\"firstHeading\"]").InnerText;

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the rarity and stars of a ship
		/// </summary>
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship nation
		/// </summary>		
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship type
		/// </summary>
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship thumbnail image
		/// </summary>
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship construction information
		/// </summary>
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

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship's skins
		/// </summary>
		public static Ship GetShipSkins(Ship ship, String baseUrl)
		{
			String skinsPageContent = new WebClient().DownloadString(baseUrl + "/Gallery");
			HtmlDocument document = new HtmlDocument();
			document.LoadHtml(skinsPageContent);

			ship.Skins = new List<ShipSkin>();

			HtmlNode tabberNode = document.DocumentNode.Descendants().First(n => n.HasClass("tabber"));

			foreach (var skinTab in tabberNode.ChildNodes.Where(n => n.Name == "div"))
			{
				ShipSkin skin = new ShipSkin();
				HtmlNode[] skinImageDescendants = skinTab.Descendants("img").ToArray();

				skin.Id = Guid.NewGuid();
				skin.Name = skinTab.Descendants("div").First().FirstChild.InnerText.Replace(ship.Name + ": ", "");

				switch (skinImageDescendants.Count())
				{
					case 1:
						skin.ImageUrl = skinImageDescendants[0].Attributes["src"].Value;
						break;
					case 2:
						skin.ImageUrl = skinImageDescendants[0].Attributes["src"].Value;
						skin.BackgroundUrl = skinImageDescendants[1].Attributes["src"].Value;
						break;
					case 3:
						skin.ChibiUrl = ImageBaseUrl + skinImageDescendants[0].Attributes["src"].Value;
						skin.ImageUrl = ImageBaseUrl + skinImageDescendants[1].Attributes["src"].Value;
						skin.BackgroundUrl = ImageBaseUrl + skinImageDescendants[2].Attributes["src"].Value;
						break;
				}


				HtmlNode skintableDescendants = skinTab.Descendants("table").First();
				HtmlNode[] tablevalues = skintableDescendants.Descendants("td").ToArray();

				skin.ObtainedFrom = tablevalues[0].InnerText;
				if (tablevalues[1].InnerHtml == "Yes") skin.Live2dModel = true;

				if (skinTab.Attributes["Title"].Value == "Default")
				{
					ship.DefaultSkin = skin;
				}

				ship.Skins.Add(skin);
			}

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get all the ship's gallery items
		/// </summary>
		public static Ship GetShipGallery(Ship ship, String baseUrl)
		{
			String skinsPageContent = new WebClient().DownloadString(baseUrl + "/Gallery");
			HtmlDocument document = new HtmlDocument();
			document.LoadHtml(skinsPageContent);

			List<ShipGalleryItem> galleryItems = new List<ShipGalleryItem>();

			try
			{
				HtmlNode artWorkgalleryNode = document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[3]");
				HtmlNode[] artWorkFrameNodes = artWorkgalleryNode.ChildNodes.Where(n => n.Name == "div").ToArray();

				foreach (var artworkFrameNode in artWorkFrameNodes)
				{
					ShipGalleryItem item = new ShipGalleryItem();

					HtmlNode imageNode = artworkFrameNode.Descendants("img").First();
					HtmlNode descriptionNode = artworkFrameNode.Descendants("div").Skip(1).First();

					item.Id = Guid.NewGuid();
					item.Description = descriptionNode.InnerText;
					item.Url = ImageBaseUrl + imageNode.Attributes["src"].Value;

					ship.Gallery.Add(item);
				}

			}
			catch { }

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// get all the ship's misc info
		/// </summary>
		public static Ship GetShipMiscInfo(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Artist = new ShipArtist();
			ship.VoiceActor = new ShipVoiceActor();
			ship.Pixiv = new ShipPixiv();
			ship.Twitter = new ShipTwitter();
			ship.Web = new ShipWeb();

			ship.Artist.Id = Guid.NewGuid();
			ship.VoiceActor.Id = Guid.NewGuid();
			ship.Pixiv.Id = Guid.NewGuid();
			ship.Twitter.Id = Guid.NewGuid();
			ship.Web.Id = Guid.NewGuid();

			String artistNodeX, vaNodeX, pixivNodeX, twitterNodeX, webNodeX = "";

			if (hasNote)
			{
				artistNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[2]/div[2]/table[1]/tbody/tr[2]/td[2]/a";
				vaNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[2]/div[2]/table[1]/tbody/tr[6]/td[2]";
				pixivNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[2]/div[2]/table[1]/tbody/tr[3]/td[2]/a";
				twitterNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[3]/div[2]/div[2]/table[1]/tbody/tr[4]/td[2]/a";
				webNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/div[2]/table[1]/tbody/tr[5]/td[2]/a";
			}
			else
			{
				artistNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[2]/td[2]/a";
				vaNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[6]/td[2]";
				pixivNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[3]/td[2]/a";
				twitterNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[4]/td[2]/a";
				webNodeX = "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[5]/td[2]/a";
			}

			// Artist
			HtmlNode artistNode = document.DocumentNode.SelectSingleNode(artistNodeX);
			if (artistNode != null)
			{
				ship.Artist.Name = artistNode.InnerText.Replace("\n", "");
				ship.Artist.Url = ImageBaseUrl + artistNode.Attributes["href"].Value.TrimStart('/');
			}
			else { ship.Artist = null; }

			// Voice Actor
			try
			{
				HtmlNode voiceActorTableNode = document.DocumentNode.SelectSingleNode(vaNodeX);
				HtmlNode voiceActorNode = null;

				int descCount = voiceActorTableNode.Descendants("a").Count();
				var desc = voiceActorTableNode.Descendants("a");
				if (descCount == 0) voiceActorNode = voiceActorTableNode;
				if (descCount > 0)
				{
					voiceActorNode = voiceActorTableNode.Descendants("a").Where(n => n.InnerText != "Play").First();
				}

				ship.VoiceActor.Name = voiceActorNode.InnerText;
				if (descCount > 0) ship.VoiceActor.Url = voiceActorNode.Attributes["href"].Value;

			}
			catch { ship.VoiceActor = null; }

			// Pixiv
			HtmlNode pixivNode = document.DocumentNode.SelectSingleNode(pixivNodeX);
			if (pixivNode != null)
			{
				ship.Pixiv.Name = pixivNode.InnerText;
				ship.Pixiv.Url = pixivNode.Attributes["href"].Value;
			}
			else { ship.Pixiv = null; }


			// Twitter
			HtmlNode twitterNode = document.DocumentNode.SelectSingleNode(twitterNodeX);
			if (twitterNode != null)
			{
				ship.Twitter.Name = twitterNode.InnerText;
				ship.Twitter.Url = twitterNode.Attributes["href"].Value;
			}
			else { ship.Twitter = null; }


			// Web
			HtmlNode webNode = document.DocumentNode.SelectSingleNode(webNodeX);
			if (webNode != null)
			{
				ship.Web.Name = webNode.InnerText;
				ship.Web.Url = webNode.Attributes["href"].Value;
			}
			else { ship.Web = null; }

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get all the ship's skills
		/// </summary>
		public static Ship GetShipSkills(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get all the ship's limit breaks
		/// </summary>
		public static Ship GetShipLimitBreaks(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// get all the ship's equippable slots
		/// </summary>
		public static Ship GetShipEquippableSlots(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get all the ship's statistics
		/// </summary>
		public static Ship GetShipStatistics(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship's enhance values
		/// </summary>
		public static Ship GetShipEnhanceValue(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get the ship's scrap values
		/// </summary>
		public static Ship GetShipScrapValue(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}

		/// <summary>
		/// Get all the ship's consctruction values
		/// </summary>
		public static Ship GetShipConstruction(Ship ship, Boolean hasNote, HtmlDocument document)
		{

			Console.WriteLine("✓ " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			return ship;
		}
	}
}