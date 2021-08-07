using System;
using System.Diagnostics;
using AzurLaneClasses.Ship;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurLaneTests
{
	[TestClass]
	public class ShipScraperTests
	{

        [TestMethod("Get standard ship [Bulldog]")]
		public void Test1()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Bulldog"));
		}

        [TestMethod("Get ship with comment [Comet]")]
		public void Test2()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Comet"));
		}

        [TestMethod("Get ship without gallery items [Universal Bulin]")]
		public void Test3()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Universal_Bulin"));
		}

        [TestMethod("Get ship with retrofit, lots of skins and gallery items [Laffey]")]
		public void Test4()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Laffey"));
		}

		[TestMethod("Get ship without voice actor link (with play file) [Shirakami Fubuki]")]
		public void Test5()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Shirakami_Fubuki"));
		}

		[TestMethod("Get ship that does not have 'Unconstructable' or a construction time [Neptune]")]
		public void Test6()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/Neptune"));
		}

		[TestMethod("Get submarine ship with extended statistics [I-19]")]
		public void Test7()
		{
			Assert.IsNotNull(AzurLaneAPI.Scrapers.ShipsScraper.GetShip("https://azurlane.koumakan.jp/I-19"));
		}
	}
}
