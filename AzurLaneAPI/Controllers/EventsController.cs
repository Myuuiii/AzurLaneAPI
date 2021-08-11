using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
	public class EventsController : ControllerBase
	{
		private AzurLaneDbContext _context;

		public EventsController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get all events
		/// </summary>
		[HttpGet(Routes.V1.Routes.Events.GetAll)]
		public async Task<ActionResult<List<ALEvent>>> GetEvents()
		{
			try
			{
				return await _context.Events.ToListAsync();
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		/// <summary>
		/// Get event by id
		/// </summary>
		/// <param name="id">Event Id</param>
		[HttpGet(Routes.V1.Routes.Events.GetId)]
		public async Task<ActionResult<ALEvent>> GetEvent(Guid id)
		{
			try
			{
				if (await _context.Events.AnyAsync(ev => ev.Id == id))
				{
					return await _context.Events.SingleAsync(ev => ev.Id == id);
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
		/// (Developer Only) Import events using scraper
		/// </summary>
		[HttpGet(Routes.V1.Routes.Events.ImportScraper)]
		public async Task<ActionResult> ImportScraper()
		{
			try
			{
				return StatusCode(501, "This scraper has not yet been implemented");
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}
	}
}