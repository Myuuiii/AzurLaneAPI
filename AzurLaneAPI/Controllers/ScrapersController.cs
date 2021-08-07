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

		/// <summary>
		/// (Developer Only) Get all the ship's wiki urls
		/// </summary>
		[HttpGet(Routes.V1.Routes.Scrapers.Ships.GetPageUrls)]
		public async Task<ActionResult<List<String>>> ScrapeShips()
		{
			if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

			return Scrapers.ShipsScraper.GetShipWikiUrls();
		}

		/// <summary>
		/// (Developer Only) Retrieve all the ships, uses our webscraper, this might take several minutes to complete.
		/// </summary>
		[HttpGet(Routes.V1.Routes.Scrapers.Ships.GetShips)]
		public async Task<ActionResult<List<Ship>>> GetShips()
		{
			if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

			String[] shipLinks = Scrapers.ShipsScraper.GetShipWikiUrls().ToArray();
			List<Ship> ships = new List<Ship>();

			foreach (var ship in shipLinks)
			{
				ships.Add(Scrapers.ShipsScraper.GetShip(ship));
			}

			return ships;
		}
	}
}