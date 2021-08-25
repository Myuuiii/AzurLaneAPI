using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using AzurLaneClasses.Ship;
using HtmlAgilityPack;

namespace AzurLaneAPI.Scrapers
{
	public static class ShipsScraper
	{
		static void Processing(string name)
		{
			try
			{
				Console.SetCursorPosition(0, Console.CursorTop);
				Console.ResetColor();
				Console.Write(name + ": ");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Processing");
				Console.ResetColor();
			}
			catch
			{
				Console.WriteLine("You are debugging and the console can not be modified");
			}
		}

		static void Done(string name)
		{
			try
			{
				Console.SetCursorPosition(0, Console.CursorTop);
				Console.ResetColor();
				Console.Write(name + ": ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("✔ Completed");
				Console.ResetColor();
			}
			catch
			{
				Console.WriteLine("You are debugging and the console can not be modified");
			}
		}

		/// <summary>
		/// Retrieve information about a ship
		/// </summary>
		public static Ship GetShip(String url)
		{
			if (GetShipWikiUrls().Contains(url))
			{
				Processing(url);

				Ship ship = new Ship();
				String shipBaseInfoPageContents = new WebClient().DownloadString($"https://azurlane.koumakan.jp/w/index.php?title={url.Split('/').Last()}&mobileaction=toggle_view_desktop");
				HtmlDocument document = new HtmlDocument();
				document.LoadHtml(shipBaseInfoPageContents);

				Boolean hasNote = GetShipHasNoteState(document);

				// ? General Data
				ship.Id = Guid.NewGuid();
				ship = GetShipId(ship, hasNote, document);
				ship = GetShipName(ship, hasNote, document);
				ship = GetShipRarityAndStars(ship, hasNote, document);
				ship = GetShipNation(ship, hasNote, document);
				ship = GetShipType(ship, hasNote, document);
				ship = GetThumbnailImage(ship, hasNote, document);
				ship = GetConstruction(ship, hasNote, document);
				ship = GetShipMiscInfo(ship, hasNote, document);
				ship = GetShipScrapValue(ship, hasNote, document);
				ship = GetShipEnhanceValue(ship, hasNote, document);
				ship = GetShipStatistics(ship, hasNote, document);
				ship = GetShipEquippableSlots(ship, hasNote, document);
				ship = GetShipSkills(ship, hasNote, document);
				ship = GetShipLimitBreaks(ship, hasNote, document);

				// ? Gallery Page
				ship = GetShipSkins(ship, url);
				ship = GetShipGallery(ship, url);

				// ? Quotes Page
				ship = GetShipQuotes(ship, url);

				Done(url);
				return ship;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Translate the XPath in case the ship page has a note which changes the structure
		/// Please do only provide XPaths of ships that do not have a note
		/// </summary>
		public static HtmlNode GetXPathNode(HtmlDocument document, String xPath, Boolean hasNote)
		{
			if (hasNote)
			{
				return document.DocumentNode.SelectSingleNode(xPath.Replace("/html/body/div[3]/div[3]/div[5]/div[1]/div[2]", "/html/body/div[3]/div[3]/div[5]/div[1]/div[3]"));
			}
			else
			{
				return document.DocumentNode.SelectSingleNode(xPath);
			}
		}

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


			foreach (var tableNode in tableNodes.Take(tableNodes.Count() - 1))
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
		/// Get wether the main ship page has a note which could switch around some Xpaths later on
		/// </summary>
		public static Boolean GetShipHasNoteState(HtmlDocument document)
		{
			return document.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]").Descendants("div").First().HasClass("hatnote");
		}

		/// <summary>
		/// Get the id of a ship
		/// </summary>
		public static Ship GetShipId(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.ShipId = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[1]/td", hasNote).InnerText.Replace("\n", "");
			return ship;
		}

		/// <summary>
		/// Get the name of a ship
		/// </summary>
		public static Ship GetShipName(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Name = document.DocumentNode.SelectSingleNode("//*[@id=\"firstHeading\"]").InnerText;
			return ship;
		}

		/// <summary>
		/// Get the rarity and stars of a ship
		/// </summary>
		public static Ship GetShipRarityAndStars(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			String[] rarityParts;

			rarityParts = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[3]/table/tbody/tr[2]/td/div", hasNote).InnerHtml.Split("<br>");

			ship.Rarity = rarityParts[0];
			ship.Stars = new ShipStars
			{
				Stars = rarityParts[1],
				Count = rarityParts[1].ToCharArray().Count()
			};
			return ship;
		}

		/// <summary>
		/// Get the ship nation
		/// </summary>		
		public static Ship GetShipNation(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Nation = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[2]/td/a[2]", hasNote).InnerText;
			return ship;
		}

		/// <summary>
		/// Get the ship type
		/// </summary>
		public static Ship GetShipType(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Type = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[4]/table/tbody/tr[3]/td/a[2]", hasNote).InnerText;
			return ship;
		}

		/// <summary>
		/// Get the ship thumbnail image
		/// </summary>
		public static Ship GetThumbnailImage(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.ThumbnailImage = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[2]/a/img", hasNote).Attributes["src"].Value;
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
				ship.Construction.ConstructionTime = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[2]/td[1]/a", hasNote).InnerText.Replace("\n", "");
				ship.Construction.Availability.Light = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[1]", hasNote).InnerText.Replace("\n", "");
				ship.Construction.Availability.Heavy = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[2]", hasNote).InnerText.Replace("\n", "");
				ship.Construction.Availability.Special = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[3]", hasNote).InnerText.Replace("\n", "");
				ship.Construction.Availability.Limited = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[3]/table/tbody/tr[4]/td[4]", hasNote).InnerText.Replace("\n", "");
			}
			catch
			{
				try
				{
					ship.Construction.ConstructionTime = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[1]/div[3]/table/tbody/tr[1]/td/a", hasNote).InnerText.Replace("\n", "");
				}
				catch
				{
					// Construction time was not set on the wiki page
					ship.Construction.ConstructionTime = "";
				}
			}
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
					default:
						skin.ChibiUrl = skinImageDescendants[0].Attributes["src"].Value;
						skin.ImageUrl = skinImageDescendants[1].Attributes["src"].Value;
						skin.BackgroundUrl = skinImageDescendants[2].Attributes["src"].Value;
						break;
				}


				HtmlNode skintableDescendants = skinTab.Descendants("table").First();
				HtmlNode[] tablevalues = skintableDescendants.Descendants("td").ToArray();

				skin.ObtainedFrom = tablevalues[0].InnerText;
				if (tablevalues[1].InnerHtml == "Yes") skin.Live2dModel = true;

				ship.Skins.Add(skin);
			}
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

					String[] urlParts = imageNode.Attributes["src"].Value.Replace("thumb/", "").Split('/');
					item.Url = String.Join('/', urlParts.Take(urlParts.Count() - 1));

					ship.Gallery.Add(item);
				}

			}
			catch { }
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

			// Artist
			HtmlNode artistNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[2]/td[2]/a", hasNote);
			if (artistNode != null)
			{
				ship.Artist.Name = artistNode.InnerText.Replace("\n", "");
				ship.Artist.Url = artistNode.Attributes["href"].Value.TrimStart('/');
			}
			else { ship.Artist = null; }

			// Voice Actor
			try
			{
				HtmlNode voiceActorTableNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[6]/td[2]", hasNote);
				HtmlNode voiceActorNode = null;

				int descCount = voiceActorTableNode.Descendants("a").Count();
				var desc = voiceActorTableNode.Descendants("a");
				if (descCount == 0) voiceActorNode = voiceActorTableNode;
				if (descCount > 0)
				{
					var c = voiceActorTableNode.Descendants("a").Where(n => n.InnerText != "Play").Count();
					if (c == 0)
					{
						voiceActorNode = voiceActorTableNode.Descendants("#text").Where(n => n.InnerText != "Play").First();
					}
					else
					{
						voiceActorNode = voiceActorTableNode.Descendants("a").Where(n => n.InnerText != "Play").First();
						ship.VoiceActor.Url = voiceActorNode.Attributes["href"].Value;
					}

				}

				ship.VoiceActor.Name = voiceActorNode.InnerText.Trim().Replace("\n", "");

			}
			catch
			{
				ship.VoiceActor = null;
			}

			// Pixiv
			HtmlNode pixivNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[3]/td[2]/a", hasNote);
			if (pixivNode != null)
			{
				ship.Pixiv.Name = pixivNode.InnerText;
				ship.Pixiv.Url = pixivNode.Attributes["href"].Value;
			}
			else
			{
				ship.Pixiv = null;
			}


			// Twitter
			HtmlNode twitterNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[4]/td[2]/a", hasNote);
			if (twitterNode != null)
			{
				ship.Twitter.Name = twitterNode.InnerText;
				ship.Twitter.Url = twitterNode.Attributes["href"].Value;
			}
			else
			{
				ship.Twitter = null;
			}


			// Web
			HtmlNode webNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody/tr[5]/td[2]/a", hasNote);
			if (webNode != null)
			{
				ship.Web.Name = webNode.InnerText;
				ship.Web.Url = webNode.Attributes["href"].Value;
			}
			else
			{
				ship.Web = null;
			}
			return ship;
		}

		/// <summary>
		/// Get the ship's scrap values
		/// </summary>
		public static Ship GetShipScrapValue(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			HtmlNode scrapNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[4]/tbody/tr[2]/td[2]", hasNote);

			try
			{
				ship.ScrapValue = new ShipScrapValues
				{
					Coins = Convert.ToInt32(scrapNode.Descendants("#text").First().InnerText.Replace("\n", "")),
					Oil = Convert.ToInt32(scrapNode.Descendants("#text").Skip(1).First().InnerText.Replace("\n", "")),
					Medals = Convert.ToInt32(scrapNode.Descendants("#text").Skip(2).First().InnerText.Replace("\n", "")),
				};
			}
			catch
			{
				ship.ScrapValue = null;
			}
			return ship;
		}

		/// <summary>
		/// Get the ship's enhance values
		/// </summary>
		public static Ship GetShipEnhanceValue(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			HtmlNode enhanceNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[4]/tbody/tr[2]/td[1]", hasNote);

			try
			{
				ship.EnhanceValue = new ShipEnhanceValues
				{
					Firepower = Convert.ToInt32(enhanceNode.Descendants("#text").First().InnerText.Replace("\n", "")),
					Torpedo = Convert.ToInt32(enhanceNode.Descendants("#text").Skip(1).First().InnerText.Replace("\n", "")),
					Aviation = Convert.ToInt32(enhanceNode.Descendants("#text").Skip(2).First().InnerText.Replace("\n", "")),
					Reload = Convert.ToInt32(enhanceNode.Descendants("#text").Skip(3).First().InnerText.Replace("\n", "")),
				};
			}
			catch
			{
				ship.EnhanceValue = null;
			}
			return ship;
		}

		/// <summary>
		/// get all the ship's equippable slots
		/// </summary>
		public static Ship GetShipEquippableSlots(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			HtmlNode[] slotNodes = new HtmlNode[3];

			slotNodes[0] = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[2]/tbody/tr[3]", hasNote);
			slotNodes[1] = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[2]/tbody/tr[4]", hasNote);
			slotNodes[2] = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/table[2]/tbody/tr[5]", hasNote);

			ship.EquippableSlots = new List<ShipEquippableSlot>();

			foreach (HtmlNode slotNode in slotNodes)
			{
				var desc = slotNode.Descendants("td");
				ShipEquippableSlot slot = new ShipEquippableSlot();
				slot.Id = Guid.NewGuid();

				string nodeContent = slotNode.Descendants("td").Skip(1).First().InnerText.Split('→').First().Replace("\n", "").Replace("%", "");
				if (nodeContent != "None")
				{
					slot.MinEfficiency = Convert.ToInt32(nodeContent);
				}

				nodeContent = slotNode.Descendants("td").Skip(1).First().InnerText.Split('→').Last().Replace("\n", "").Replace("%", "");
				if (nodeContent != "None")
				{
					slot.MaxEfficiency = Convert.ToInt32(nodeContent);
				}

				slot.Type = slotNode.Descendants("td").Skip(2).First().InnerText.Replace("\n", "");
				slot.Max = Convert.ToInt32(slotNode.Descendants("td").Skip(3).First().InnerText.Split('→').Last().Replace("\n", ""));

				ship.EquippableSlots.Add(slot);
			}
			return ship;
		}

		/// <summary>
		/// Get all the ship's statistics
		/// </summary>
		public static Ship GetShipStatistics(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			HtmlNode tableBodyNode = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/div[2]/div[2]/div/table/tbody", hasNote);
			HtmlNode[] statRows = tableBodyNode.ChildNodes.Where(n => n.Name == "tr").Skip(1).Take(tableBodyNode.ChildNodes.Where(n => n.Name == "tr").Skip(1).Count() - 1).ToArray();

			List<ShipStats> shipStats = new List<ShipStats>();

			for (int i = 0; i < statRows.Count(); i++)
			{
				HtmlNode statRow = statRows[i];

				ShipStats stat = new ShipStats();
				stat.Id = Guid.NewGuid();
				var node = statRow.ChildNodes.Where(n => n.Name == "td").Skip(1).First();
				stat.Health = Convert.ToInt32(node.InnerText.Replace("\n", ""));
				stat.Firepower = Convert.ToInt32(statRow.Descendants("td").Skip(2).First().InnerText.Replace("\n", ""));
				stat.Torpedo = Convert.ToInt32(statRow.Descendants("td").Skip(3).First().InnerText.Replace("\n", ""));
				stat.Evasion = Convert.ToInt32(statRow.Descendants("td").Skip(4).First().InnerText.Replace("\n", ""));
				stat.Speed = Convert.ToInt32(statRow.Descendants("td").Skip(5).First().InnerText.Replace("\n", ""));

				if (i == 0)
				{
					stat.Armor = statRow.Descendants("td").Skip(6).First().InnerText.Replace("\n", "");

					stat.Reload = Convert.ToInt32(statRow.Descendants("td").Skip(7).First().InnerText.Replace("\n", ""));
					stat.AntiAir = Convert.ToInt32(statRow.Descendants("td").Skip(8).First().InnerText.Replace("\n", ""));
					stat.Aviation = Convert.ToInt32(statRow.Descendants("td").Skip(9).First().InnerText.Replace("\n", ""));
					stat.OilConsumption = Convert.ToInt32(statRow.Descendants("td").Skip(10).First().InnerText.Replace("\n", ""));
					stat.Accuracy = Convert.ToInt32(statRow.Descendants("td").Skip(11).First().InnerText.Replace("\n", ""));
					stat.Luck = Convert.ToInt32(statRow.Descendants("td").Skip(12).First().InnerText.Replace("\n", ""));
					stat.AntiSubmarine = Convert.ToInt32(statRow.Descendants("td").Skip(13).First().InnerText.Replace("\n", ""));
				}
				else
				{
					stat.Armor = statRows[0].Descendants("td").Skip(6).First().InnerText.Replace("\n", "");

					stat.Reload = Convert.ToInt32(statRow.Descendants("td").Skip(6).First().InnerText.Replace("\n", ""));
					stat.AntiAir = Convert.ToInt32(statRow.Descendants("td").Skip(7).First().InnerText.Replace("\n", ""));
					stat.Aviation = Convert.ToInt32(statRow.Descendants("td").Skip(8).First().InnerText.Replace("\n", ""));
					stat.OilConsumption = Convert.ToInt32(statRow.Descendants("td").Skip(9).First().InnerText.Replace("\n", ""));
					stat.Accuracy = Convert.ToInt32(statRow.Descendants("td").Skip(10).First().InnerText.Replace("\n", ""));
					stat.Luck = Convert.ToInt32(statRow.Descendants("td").Skip(11).First().InnerText.Replace("\n", ""));
					stat.AntiSubmarine = Convert.ToInt32(statRow.Descendants("td").Skip(12).First().InnerText.Replace("\n", ""));
				}

				shipStats.Add(stat);
			}

			if (shipStats.Count == 3)
			{
				ship.Level120Stats = shipStats[0];
				ship.Level100Stats = shipStats[1];
				ship.BaseStats = shipStats[2];
			}
			else if (shipStats.Count == 5)
			{
				ship.Level120RetrofitStats = shipStats[0];
				ship.Level120Stats = shipStats[1];
				ship.Level100RetrofitStats = shipStats[2];
				ship.Level100Stats = shipStats[3];
				ship.BaseStats = shipStats[4];
			}
			return ship;
		}

		/// <summary>
		/// Get all the ship's limit breaks
		/// </summary>
		public static Ship GetShipLimitBreaks(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.LimitBreaks = new List<ShipLimitBreaks>();

			ship.LimitBreaks.Add(new ShipLimitBreaks
			{
				LimitBreaks = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[2]/td[1]", hasNote).InnerText.Replace("\n", "").Split(" / ")
			});

			ship.LimitBreaks.Add(new ShipLimitBreaks
			{
				LimitBreaks = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[3]/td[1]", hasNote).InnerText.Replace("\n", "").Split(" / ")
			});

			ship.LimitBreaks.Add(new ShipLimitBreaks
			{
				LimitBreaks = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[4]/td[1]", hasNote).InnerText.Replace("\n", "").Split(" / ")
			});
			return ship;
		}

		/// <summary>
		/// Get all the ship's skills
		/// </summary>
		public static Ship GetShipSkills(Ship ship, Boolean hasNote, HtmlDocument document)
		{
			ship.Skills = new List<ShipSkill>();

			if (GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[2]/td[2]/b", hasNote) != null)
			{
				ship.Skills.Add(new ShipSkill
				{
					Name = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[2]/td[2]/b", hasNote).InnerText.Replace("\n", ""),
					Description = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[2]/td[3]", hasNote).InnerText.Replace("\n", "")

				});
			}

			if (GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[3]/td[2]/b", hasNote) != null)
			{
				ship.Skills.Add(new ShipSkill
				{
					Name = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[3]/td[2]/b", hasNote).InnerText.Replace("\n", ""),
					Description = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[3]/td[3]", hasNote).InnerText.Replace("\n", "")
				});
			}


			if (GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[4]/td[2]/b", hasNote) != null)
			{
				ship.Skills.Add(new ShipSkill
				{
					Name = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[4]/td[2]/b", hasNote).InnerText.Replace("\n", ""),
					Description = GetXPathNode(document, "/html/body/div[3]/div[3]/div[5]/div[1]/div[2]/table/tbody/tr[4]/td[3]", hasNote).InnerText.Replace("\n", "")
				});
			}
			return ship;
		}

		private static Ship GetShipQuotes(Ship ship, string url)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(new WebClient().DownloadString(url + "/Quotes?mobileaction=toggle_view_mobile"));

			// The item that contains all the lists for all the servers
			HtmlNode tabber = doc.DocumentNode.Descendants().Where(n => n.HasClass("tabber")).First();
			HtmlNode englishServer, chineseServer, japaneseServer;
			englishServer = chineseServer = japaneseServer = null;

			List<ShipQuote> quotes = new List<ShipQuote>();

			if (tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "english server").Count() > 0)
			{
				englishServer = tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "english server").First();
			}
			if (tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "chinese server").Count() > 0)
			{
				chineseServer = tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "chinese server").First();
			}
			if (tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "japanese server").Count() > 0)
			{
				japaneseServer = tabber.ChildNodes.Where(n => n.OriginalName == "div" && n.Attributes["title"].Value.ToLower() == "japanese server").First();
			}


			// English Server Quote Loops
			if (englishServer != null)
			{
				IEnumerable<HtmlNode> enTables = englishServer.ChildNodes.Where(n => n.OriginalName == "table");
				for (int tableNr = 0; tableNr < enTables.Count(); tableNr++)
				{
					foreach (HtmlNode table in enTables)
					{
						quotes = ProcessQuotesTable(quotes, table, englishServer.ChildNodes.Where(n => n.OriginalName == "h3").ToArray()[tableNr].InnerText, "EN");
					}
				}
			}


			// Chinese Server Quote Loops
			if (chineseServer != null)
			{
				IEnumerable<HtmlNode> cnTables = chineseServer.ChildNodes.Where(n => n.OriginalName == "table");
				for (int tableNr = 0; tableNr < cnTables.Count(); tableNr++)
				{
					foreach (HtmlNode table in cnTables)
					{
						quotes = ProcessQuotesTable(quotes, table, chineseServer.ChildNodes.Where(n => n.OriginalName == "h3").ToArray()[tableNr].InnerText, "CN");
					}
				}

			}


			// Japanese Server Quote Loops
			if (japaneseServer != null)
			{
				IEnumerable<HtmlNode> jpTables = japaneseServer.ChildNodes.Where(n => n.OriginalName == "table");
				for (int tableNr = 0; tableNr < jpTables.Count(); tableNr++)
				{
					foreach (HtmlNode table in jpTables)
					{
						quotes = ProcessQuotesTable(quotes, table, japaneseServer.ChildNodes.Where(n => n.OriginalName == "h3").ToArray()[tableNr].InnerText, "JP");
					}
				}
			}

			ship.Quotes = quotes;
			return ship;
		}

		/// <summary>
		/// Get all the ship's quotes
		/// </summary>
		static List<ShipQuote> ProcessQuotesTable(List<ShipQuote> quotes, HtmlNode tableNode, String skinName, String language)
		{
			// Skip the first TR as it contains the headers
			if (tableNode.Descendants("tr").Count() > 1)
			{
				HtmlNode[] rows = tableNode.Descendants("tr").ToArray();
				for (int rowNr = 1; rowNr < rows.Count(); rowNr++)
				{

					ShipQuote quote = new ShipQuote();
					HtmlNode[] nodeColumns = rows[rowNr].ChildNodes.Where(n => n.OriginalName == "td").ToArray();
					nodeColumns.Last().InnerHtml = "";

					if (quotes.Any(q => q.Event == nodeColumns[0].InnerText.Replace("\n", "")))
					{
						quote = quotes.Single(q => q.Event == nodeColumns[0].InnerText.Replace("\n", ""));
					}
					else
					{
						quote = new ShipQuote();
						quote.Id = Guid.NewGuid();
						quote.Skin = skinName;
					}

					quote.Event = nodeColumns[0].InnerText.Replace("\n", "");

					if (nodeColumns.Count() == 4)
					{
						// English Table
						quote.EN_Transcription = nodeColumns[2].InnerText.Replace("\n", "");

						if (nodeColumns[3].ChildNodes.Where(n => n.OriginalName == "a").Count() > 0)
						{
							quote.AudioUrl = nodeColumns[1].ChildNodes.Where(n => n.OriginalName == "a").ToArray()[0].Attributes["href"].Value;
						}
					}
					else if (nodeColumns.Count() == 5)
					{
						// Japanese or Chinese Table
						if (language == "JP")
						{
							quote.JP_Transcription = nodeColumns[2].InnerText.Replace("\n", "");
						}
						else if (language == "CN")
						{
							quote.CN_Transcription = nodeColumns[2].InnerText.Replace("\n", "");
						}
						else if (language == "EN")
						{
							quote.EN_Transcription = nodeColumns[3].InnerText.Replace("\n", "");
						}
					}
					else if (nodeColumns.Count() == 6)
					{
						// Chinese Table with chinese audio
						quote.CN_Transcription = nodeColumns[3].InnerText.Replace("\n", "");
					}

					if (quote.AudioUrl == null)
					{
						if (nodeColumns[1].ChildNodes.Where(n => n.OriginalName == "a").Count() > 0)
						{
							quote.AudioUrl = nodeColumns[1].ChildNodes.Where(n => n.OriginalName == "a").ToArray()[0].Attributes["href"].Value;
						}
					}

					if (!quotes.Any(q => q.Event == quote.Event))
					{
						quotes.Add(quote);
					}
				}
			}

			return quotes;
		}
	}
}