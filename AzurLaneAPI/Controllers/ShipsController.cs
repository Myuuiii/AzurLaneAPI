using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Import;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AzurLaneAPI.Controllers
{
	public partial class ShipsController : Controller
	{
		private AzurLaneDbContext _context;

		public ShipsController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieve all ships, limited to 20 per page for users without API key
		/// </summary>
		/// <param name="page">Page Number</param>
		/// <param name="itemsPerPage">Items to display per page, limited to 20 without API key</param>
		[HttpGet(Routes.V1.Routes.Ships.GetAll)]
		public async Task<ActionResult<List<Ship>>> GetShips(Int32? page = null, Int32? itemsPerPage = null)
		{
			try
			{
				if (page == null && itemsPerPage == null)
				{
					if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

					return await _context.Ships
					.Include(s => s.Stars)
					.Include(s => s.Skins)
					.Include(s => s.Skills)
					.Include(s => s.LimitBreaks)
					.Include(s => s.Gallery)
					.Include(s => s.EquippableSlots)
					.Include(s => s.BaseStats)
					.Include(s => s.Level100Stats)
					.Include(s => s.Level120Stats)
					.Include(s => s.Level100RetrofitStats)
					.Include(s => s.Level120RetrofitStats)
					.Include(s => s.EnhanceValue)
					.Include(s => s.ScrapValue)
					.Include(s => s.Construction)
					.Include(s => s.Construction.Availability)
					.Include(s => s.Artist)
					.Include(s => s.Pixiv)
					.Include(s => s.Twitter)
					.Include(s => s.Web)
					.Include(s => s.VoiceActor)
						.ToListAsync();
				}
				else if (page == null && itemsPerPage != null) return BadRequest("You need to define a page number");
				else if (page != null && itemsPerPage == null) return BadRequest("You need to define the amount of ships per page");
				else if (page != null && itemsPerPage != null)
				{

					if (itemsPerPage > 20)
					{
						if (!Helpers.Authenticate(HttpContext)) return Unauthorized("You need an API key to retrieve more than 20 ships at a time");
					}

					var skip = (page - 1) * itemsPerPage;

					HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(_context.Ships.ToArray().Length / itemsPerPage));
					HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
					return await _context.Ships
					.Include(s => s.Stars)
					.Include(s => s.Skins)
					.Include(s => s.Skills)
					.Include(s => s.LimitBreaks)
					.Include(s => s.Gallery)
					.Include(s => s.EquippableSlots)
					.Include(s => s.BaseStats)
					.Include(s => s.Level100Stats)
					.Include(s => s.Level120Stats)
					.Include(s => s.Level100RetrofitStats)
					.Include(s => s.Level120RetrofitStats)
					.Include(s => s.EnhanceValue)
					.Include(s => s.ScrapValue)
					.Include(s => s.Construction)
					.Include(s => s.Construction.Availability)
					.Include(s => s.Artist)
					.Include(s => s.Pixiv)
					.Include(s => s.Twitter)
					.Include(s => s.Web)
					.Include(s => s.VoiceActor)
					.Skip((Int32)skip).Take((Int32)itemsPerPage)
						.ToListAsync();
				}
				else
				{
					return BadRequest("Something was not formatted correctly in your request");
				}

			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


		/// <summary>
		/// Get all minimal ships, limited to 20 per page without API key
		/// </summary>
		/// <param name="page">Page Number</param>
		/// <param name="itemsPerPage">Items to display per page, limited to 20 without API key</param>
		[HttpGet(Routes.V1.Routes.Ships.GetAllMinimal)]
		public async Task<ActionResult<List<MinimalShip>>> GetMinimalShips(Int32? page = null, Int32? itemsPerPage = null)
		{
			try
			{
				List<MinimalShip> minimalShips = new List<MinimalShip>();
				List<Ship> fullShips = await _context.Ships.ToListAsync();

				foreach (Ship ship in fullShips)
				{
					minimalShips.Add(new MinimalShip(ship));
				}

				if (page == null && itemsPerPage == null)
				{
					if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

					return minimalShips;
				}
				else if (page == null && itemsPerPage != null) return BadRequest("You need to define a page number");
				else if (page != null && itemsPerPage == null) return BadRequest("You need to define the amount of ships per page");
				else if (page != null && itemsPerPage != null)
				{
					if (itemsPerPage > 20)
					{
						if (!Helpers.Authenticate(HttpContext)) return Unauthorized("You need an API key to retrieve more than 20 ships at a time");
					}

					var skip = (page - 1) * itemsPerPage;

					HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(_context.Ships.ToArray().Length / itemsPerPage));
					HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
					return minimalShips.Skip((Int32)skip).Take((Int32)itemsPerPage).ToList();
				}
				else
				{
					return BadRequest("Something was not formatted correctly in your request");
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


		/// <summary>
		/// Retrieve a ship by Ship Id (e.g. 019 for "Laffey")
		/// </summary>
		/// <param name="id">Ship Id</param>
		[HttpGet(Routes.V1.Routes.Ships.GetId)]
		public async Task<ActionResult<Ship>> GetShip(String id)
		{
			try
			{
				if (await _context.Ships.AnyAsync(ship => ship.ShipId == id))
				{
					Ship ship = await _context.Ships
					.Include(s => s.Stars)
					.Include(s => s.Skins)
					.Include(s => s.Skills)
					.Include(s => s.LimitBreaks)
					.Include(s => s.Gallery)
					.Include(s => s.EquippableSlots)
					.Include(s => s.BaseStats)
					.Include(s => s.Level100Stats)
					.Include(s => s.Level120Stats)
					.Include(s => s.Level100RetrofitStats)
					.Include(s => s.Level120RetrofitStats)
					.Include(s => s.EnhanceValue)
					.Include(s => s.ScrapValue)
					.Include(s => s.Construction)
					.Include(s => s.Construction.Availability)
					.Include(s => s.Artist)
					.Include(s => s.Pixiv)
					.Include(s => s.Twitter)
					.Include(s => s.Web)
					.Include(s => s.VoiceActor)
						.SingleAsync(ship => ship.ShipId == id);
					return ship;
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


		/// <summary>
		/// Get minimal ship information using the Ship Id
		/// </summary>
		/// <param name="id">Ship Id</param>
		[HttpGet(Routes.V1.Routes.Ships.GetMinimalId)]
		public async Task<ActionResult<MinimalShip>> GetMinimalShip(String id)
		{
			try
			{
				if (await _context.Ships.AnyAsync(ship => ship.ShipId == id))
				{
					return new MinimalShip(await _context.Ships.SingleAsync(ship => ship.ShipId == id));
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


		/// <summary>
		/// Get a ship by ship name
		/// </summary>
		/// <param name="name">Ship Name</param>        
		[HttpGet(Routes.V1.Routes.Ships.GetName)]
		public async Task<ActionResult<Ship>> GetByName(string name)
		{
			try
			{
				if (await _context.Ships.AnyAsync(ship => ship.Name == name))
				{
					Ship ship = await _context.Ships
					.Include(s => s.Stars)
					.Include(s => s.Skins)
					.Include(s => s.Skills)
					.Include(s => s.LimitBreaks)
					.Include(s => s.Gallery)
					.Include(s => s.EquippableSlots)
					.Include(s => s.BaseStats)
					.Include(s => s.Level100Stats)
					.Include(s => s.Level120Stats)
					.Include(s => s.Level100RetrofitStats)
					.Include(s => s.Level120RetrofitStats)
					.Include(s => s.EnhanceValue)
					.Include(s => s.ScrapValue)
					.Include(s => s.Construction)
					.Include(s => s.Construction.Availability)
					.Include(s => s.Artist)
					.Include(s => s.Pixiv)
					.Include(s => s.Twitter)
					.Include(s => s.Web)
					.Include(s => s.VoiceActor)
						.SingleAsync(ship => ship.Name == name);
					return ship;
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


		/// <summary>
		/// Get minimal ship information using ship name
		/// </summary>
		/// <param name="name">Ship Name</param>
		[HttpGet(Routes.V1.Routes.Ships.GetMinimalName)]
		public async Task<ActionResult<MinimalShip>> GetMinimalByName(string name)
		{
			try
			{
				if (await _context.Ships.AnyAsync(ship => ship.Name == name))
				{
					return new MinimalShip(await _context.Ships.SingleAsync(ship => ship.Name == name));
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		/// <summary>
		/// (Developer Only) Import ships using scraper
		/// </summary>
		[HttpPut(Routes.V1.Routes.Ships.ImportScraper)]
		public async Task<ActionResult> ImportShipsScraper()
		{
			try
			{
				if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

				int failedShips = 0;

				List<Ship> ships = new List<Ship>();
				foreach (String url in Scrapers.ShipsScraper.GetShipWikiUrls())
				{
					try
					{
						ships.Add(Scrapers.ShipsScraper.GetShip(url));
					}
					catch
					{
						failedShips++;
					}
				}

				_context.Ships.RemoveRange(_context.Ships
						.Include(s => s.Stars)
					.Include(s => s.Skins)
					.Include(s => s.Skills)
					.Include(s => s.LimitBreaks)
					.Include(s => s.Gallery)
					.Include(s => s.EquippableSlots)
					.Include(s => s.BaseStats)
					.Include(s => s.Level100Stats)
					.Include(s => s.Level120Stats)
					.Include(s => s.Level100RetrofitStats)
					.Include(s => s.Level120RetrofitStats)
					.Include(s => s.EnhanceValue)
					.Include(s => s.ScrapValue)
					.Include(s => s.Construction)
					.Include(s => s.Construction.Availability)
					.Include(s => s.Artist)
					.Include(s => s.Pixiv)
					.Include(s => s.Twitter)
					.Include(s => s.Web)
					.Include(s => s.VoiceActor));
				_context.SaveChanges();

				_context.AddRange(ships);
				HttpContext.Response.Headers.Add("Failed Imports", failedShips.ToString());

				await _context.SaveChangesAsync();
				return Ok("API Data was successfully updated");
			}
			catch (Exception e)
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure + "\n\n" + e.ToString());
			}
		}
	}
}
