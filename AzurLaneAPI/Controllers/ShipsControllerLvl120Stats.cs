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
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Level120Stats.Get)]
        public async Task<ActionResult<ShipStats>> GetLvl120Stats(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    return ctx.Ships.Single(ship => ship.Id == id).Level120Stats;
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.Level120Stats.Create)]
        public async Task<ActionResult<ShipStats>> CreateLvl120Stats(Guid id, [FromBody] ShipStats stats)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    if (selectedShip.Level120Stats == null)
                    {
                        selectedShip.Level120Stats = stats;
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.Level120Stats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateLvl120Stats(Guid id, [FromBody] ShipStats stats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.Level120Stats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteLvl120Stats(Guid id)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships.Single(ship => ship.Id == id);
                    selectedShip.Level120Stats = null;
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