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

        [HttpPost(Routes.V1.Routes.Events.Create)]
        public async Task<ActionResult<ALEvent>> CreateEvent([FromBody] ALEvent aLEvent)
        {
            try
            {
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

        [HttpDelete(Routes.V1.Routes.Events.Delete)]
        public async Task<ActionResult<ALEvent>> DeleteEvent(Guid id)
        {
            try
            {
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