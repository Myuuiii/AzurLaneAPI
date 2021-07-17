using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public class ShipsController : Controller
    {
        [HttpGet(Routes.V1.Routes.Ships.GetShips)]
        public async Task<ActionResult<List<Ship>>> GetShips()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.Ships.ToListAsync();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet(Routes.V1.Routes.Ships.GetShipById)]
        public async Task<ActionResult<Ship>> GetShipById(String shipId)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships.AnyAsync(ship => ship.ShipId == shipId))
                {
                    return await ctx.Ships.SingleAsync(ship => ship.ShipId == shipId);
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

        [HttpPost(Routes.V1.Routes.Ships.CreateShip)]
        public async Task<ActionResult<Ship>> CreateShip([FromBody] Ship ship)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                ctx.Ships.Add(ship);
                await ctx.SaveChangesAsync();
                return ship;
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}