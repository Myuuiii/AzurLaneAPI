using System;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public partial class ShipsController
    {
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Level100Stats.Get)]
        public async Task<ActionResult<ShipStats>> GetLvl100Stats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.ShipId == id).Level100Stats;
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.Level100Stats.Create)]
        public async Task<ActionResult<ShipStats>> CreateLvl100Stats(String id, [FromBody] ShipStats stats)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    Ship selectedShip = ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.ShipId == id);

                    if (selectedShip.Level100Stats == null)
                    {
                        selectedShip.Level100Stats = stats;
                        await ctx.SaveChangesAsync();
                        return stats;
                    }
                    else
                    {
                        return StatusCode(409);
                    }
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.Level100Stats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateLvl100Stats(String id, [FromBody] ShipStats stats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.Level100Stats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteLvl100Stats(String id)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    Ship selectedShip = ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.ShipId == id);
                        
                    selectedShip.Level100Stats = null;
                    await ctx.SaveChangesAsync();
                    return Ok();
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