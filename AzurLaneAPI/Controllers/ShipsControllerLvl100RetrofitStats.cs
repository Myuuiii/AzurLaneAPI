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
        /// Retrieve a ship's level 100 retrofit stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100Retro)]
        public async Task<ActionResult<ShipStats>> GetLvl100RetrofitStats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level100RetrofitStats)
                        .Single(ship => ship.ShipId == id).Level100RetrofitStats;
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