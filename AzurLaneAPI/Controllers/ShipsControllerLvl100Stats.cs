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
        /// Retrieve a ship's level 100 stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100)]
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


        /// <summary>
        /// Retrieve a ship's level 100 stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100Name)]
        public async Task<ActionResult<ShipStats>> GetLvl100StatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.Name == name).Level100Stats;
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