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
        /// Create a new event
        /// </summary>
        /// <param name="event">Event object</param>
        [HttpPost(Routes.V1.Routes.Events.Create)]
        public async Task<ActionResult<ALEvent>> CreateEvent([FromBody] ALEvent aLEvent)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();
                
                aLEvent.Id = Guid.NewGuid();
                _context.Events.Add(aLEvent);
                await _context.SaveChangesAsync();
                return aLEvent;
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        /// <summary>
        /// Update an event
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <param name="event">Event object</param>
        [HttpPatch(Routes.V1.Routes.Events.Update)]
        public async Task<ActionResult<ALEvent>> UpdateEvent(Guid id, [FromBody] ALEvent aLEvent)
        {
            try
            {
                return StatusCode(501);
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        /// <summary>
        /// Delete an event
        /// </summary>
        /// <param name="id">Event Id</param>
        [HttpDelete(Routes.V1.Routes.Events.Delete)]
        public async Task<ActionResult<ALEvent>> DeleteEvent(Guid id)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                if (await _context.Events.AnyAsync(ev => ev.Id == id))
                {
                    ALEvent selectedEvent = _context.Events.Single(ev => ev.Id == id);
                    _context.Events.Remove(selectedEvent);
                    await _context.SaveChangesAsync();
                    return selectedEvent;
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
    }
}