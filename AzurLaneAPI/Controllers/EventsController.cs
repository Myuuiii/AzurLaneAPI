using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public class EventsController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Events.GetEvents)]
        public async Task<ActionResult<List<ALEvent>>> GetAlLEvents()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.Events.ToListAsync();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet(Routes.V1.Routes.Events.GetEventById)]
        public async Task<ActionResult<ALEvent>> GetEventById(Guid eventId)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Events.AnyAsync(ev => ev.Id == eventId))
                {
                    return await ctx.Events.SingleAsync(ev => ev.Id == eventId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}