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
        [HttpGet(Routes.V1.Routes.Ships.GetAll)]
        public async Task<ActionResult<List<Ship>>> GetShips()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.Ships.ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Ships.GetId)]
        public async Task<ActionResult<Ship>> GetShip(String shipId)
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
                    return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
                }
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpPost(Routes.V1.Routes.Ships.Create)]
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
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpPatch(Routes.V1.Routes.Ships.Update)]
        public async Task<ActionResult<ALEvent>> UpdateShip(String shipId, [FromBody] Ship ship)
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

        [HttpDelete(Routes.V1.Routes.Ships.Delete)]
        public async Task<ActionResult<Ship>> DeleteShip(String shipId)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships.AnyAsync(ship => ship.ShipId == shipId))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.ShipId == shipId);
                    ctx.Ships.Remove(selectedShip);
                    await ctx.SaveChangesAsync();
                    return selectedShip;
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