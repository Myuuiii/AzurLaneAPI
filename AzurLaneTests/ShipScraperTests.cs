using System;
using AzurLaneClasses.Ship;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurLaneTests
{
	[TestClass]
	public class ShipScraperTests
	{

        [TestMethod("Get standard ship")]
		public void Test1()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Bulldog"));
		}

        [TestMethod("Get ship with comment")]
		public void Test2()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Comet"));
		}

        [TestMethod("Get ship without gallery items")]
		public void Test3()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Universal_Bulin"));
		}

        [TestMethod("Get ship with retrofit, lots of skins and gallery items")]
		public void Test4()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Laffey"));
		}

		[TestMethod("Get ship without voice actor link (with play file)")]
		public void Test5()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Shirakami_Fubuki"));
		}

		[TestMethod("Get ship that does not have 'Unconstructable' or a construction time")]
		public void Test6()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Neptune"));
		}
	}
}
