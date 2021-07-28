using System;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public partial class ShipsController
    {
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Level120RetrofitStats.Get)]
        public async Task<ActionResult<ShipStats>> GetLvl120RetrofitStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    return ctx.Ships.Single(ship => ship.Id == id).Level120RetrofitStats;
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.Level120RetrofitStats.Create)]
        public async Task<ActionResult<ShipStats>> CreateLvl120RetrofitStats(Guid id, [FromBody] ShipStats stats)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    if (selectedShip.Level120RetrofitStats == null)
                    {
                        selectedShip.Level120RetrofitStats = stats;
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.Level120RetrofitStats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateLvl120RetrofitStats(Guid id, [FromBody] ShipStats stats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.Level120RetrofitStats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteLvl120RetrofitStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    selectedShip.Level120RetrofitStats = null;
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