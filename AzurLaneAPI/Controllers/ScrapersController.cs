using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses;
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
	}
}