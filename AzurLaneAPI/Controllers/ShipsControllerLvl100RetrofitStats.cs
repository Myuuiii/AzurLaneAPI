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
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Level100RetrofitStats.Get)]
        public async Task<ActionResult<ShipStats>> GetLvl100RetrofitStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    return ctx.Ships.Single(ship => ship.Id == id).Level100RetrofitStats;
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.Level100RetrofitStats.Create)]
        public async Task<ActionResult<ShipStats>> CreateLvl100RetrofitStats(Guid id, [FromBody] ShipStats stats)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    if (selectedShip.Level100RetrofitStats == null)
                    {
                        selectedShip.Level100RetrofitStats = stats;
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.Level100RetrofitStats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateLvl100RetrofitStats(Guid id, [FromBody] ShipStats stats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.Level100RetrofitStats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteLvl100RetrofitStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    selectedShip.Level100RetrofitStats = null;
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