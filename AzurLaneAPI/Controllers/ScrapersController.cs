using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class ScrapersController : Controller
    {
        private AzurLaneDbContext _context;

		public ScrapersController(AzurLaneDbContext context)
		{
			_context = context;
		}

		[HttpGet(Routes.V1.Routes.Scrapers.Ships.GetPageUrls)]
		public async Task<ActionResult<List<String>>> ScrapeShips()
		{
			return Scrapers.ShipsScraper.GetShipWikiUrls();
		}

		[HttpGet(Routes.V1.Routes.Scrapers.Ships.GetShips)]
		public async Task<ActionResult<List<Ship>>> GetShips()
		{
			// Comet
			// Neptune
			// Ritsuko Akizuki

			// Scrapers.ShipsScraper.GetShipBaseInfo("https://azurlane.koumakan.jp/Ritsuko_Akizuki");
			// return Ok();
			foreach (var ship in Scrapers.ShipsScraper.GetShipWikiUrls())
			{
				Scrapers.ShipsScraper.GetShipBaseInfo(ship);
			}
			
			return Ok();
		}
	}
}