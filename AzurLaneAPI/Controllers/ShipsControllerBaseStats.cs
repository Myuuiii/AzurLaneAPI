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
        /// <summary>
        /// Retrieve a ship's base stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Base)]
        public async Task<ActionResult<ShipStats>> GetBaseStats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.BaseStats)
                        .Single(ship => ship.ShipId == id).BaseStats;
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
        /// Retrieve a ship's base stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.BaseName)]
        public async Task<ActionResult<ShipStats>> GetBaseStatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.BaseStats)
                        .Single(ship => ship.Name == name).BaseStats;
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