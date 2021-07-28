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
        [HttpGet(Routes.V1.Routes.Ships.Misc.GetByRarity)]
        public async Task<ActionResult<List<Ship>>> GetByRarity(ShipRarity rarity)
        {
            try 
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                var ships = await ctx.Ships.Where(s => s.Rarity == rarity).ToListAsync();
                return ships;
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Ships.Misc.GetByType)]
        public async Task<ActionResult<List<Ship>>> GetByType(ShipType type)
        {
            try 
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                var ships = await ctx.Ships.Where(s => s.Type == type).ToListAsync();
                return ships;
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}