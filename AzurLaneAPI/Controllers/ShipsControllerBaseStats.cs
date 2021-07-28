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
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.BaseStats.Get)]
        public async Task<ActionResult<ShipStats>> GetBaseStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    return ctx.Ships.Single(ship => ship.Id == id).BaseStats;
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.BaseStats.Create)]
        public async Task<ActionResult<ShipStats>> CreateBaseStats(Guid id, [FromBody] ShipStats stats)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    if (selectedShip.BaseStats == null)
                    {
                        selectedShip.BaseStats = stats;
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.BaseStats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateBaseStats(Guid id, [FromBody] ShipStats stats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.BaseStats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteBaseStats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    selectedShip.BaseStats = null;
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