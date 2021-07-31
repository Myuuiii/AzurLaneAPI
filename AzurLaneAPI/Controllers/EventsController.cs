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
        /// <summary>
        /// Get all events
        /// </summary>
        [HttpGet(Routes.V1.Routes.Events.GetAll)]
        public async Task<ActionResult<List<ALEvent>>> GetEvents()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.Events.ToListAsync();
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
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Events.AnyAsync(ev => ev.Id == id))
                {
                    return await ctx.Events.SingleAsync(ev => ev.Id == id);
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

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                aLEvent.Id = Guid.NewGuid();
                ctx.Events.Add(aLEvent);
                await ctx.SaveChangesAsync();
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

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Events.AnyAsync(ev => ev.Id == id))
                {
                    ALEvent selectedEvent = ctx.Events.Single(ev => ev.Id == id);
                    ctx.Events.Remove(selectedEvent);
                    await ctx.SaveChangesAsync();
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