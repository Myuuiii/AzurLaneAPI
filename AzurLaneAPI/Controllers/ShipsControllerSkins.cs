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
    public partial class ShipsController
    {
        /// <summary>
        /// Retrieve all the skins of a ship 
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.Skins.GetAll)]
        public async Task<ActionResult<List<ShipSkin>>> GetAllSkinsAsync(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.ShipId == id))
                {
                    var ship = ctx.Ships
                        .Include(s => s.Skins)
                        .Single(s => s.ShipId == id);

                    return ship.Skins;
                }
                else
                {
                    return StatusCode(404, Errors.V1.Errors.X400.ResourceNotFound);
                }
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }


        /// <summary>
        /// Retrieve all the skins of a ship using the name of the ship
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.Skins.GetAllByName)]
        public async Task<ActionResult<List<ShipSkin>>> GetAllSkinsByShipNameAsync(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.Name == name))
                {
                    var ship = ctx.Ships
                        .Include(s => s.Skins)
                        .Single(s => s.Name == name);

                    return ship.Skins;
                }
                else
                {
                    return StatusCode(404, Errors.V1.Errors.X400.ResourceNotFound);
                }
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}