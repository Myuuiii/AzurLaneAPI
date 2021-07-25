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
    public class ShipsController : Controller
    {
        [HttpGet(Routes.V1.Routes.Ships.GetAll)]
        public async Task<ActionResult<List<Ship>>> GetShips()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.Ships
                    .Include(s => s.BaseStats).Include(s => s.Level100Stats).Include(s => s.Level120Stats)
                    .Include(s => s.Level100RetrofitStats).Include(s => s.Level120RetrofitStats)
                    .Include(s => s.Skins)
                    .ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Ships.GetId)]
        public async Task<ActionResult<Ship>> GetShip(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships
                    .AnyAsync(ship => ship.Id == id))
                {
                    return await ctx.Ships
                        .Include(s => s.BaseStats).Include(s => s.Level100Stats).Include(s => s.Level120Stats)
                        .Include(s => s.Level100RetrofitStats).Include(s => s.Level120RetrofitStats)
                        .Include(s => s.Skins)
                        .SingleAsync(ship => ship.Id == id);
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

        [HttpPost(Routes.V1.Routes.Ships.Create)]
        public async Task<ActionResult<Ship>> CreateShip([FromBody] Ship ship)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                ctx.Ships.Add(ship);
                await ctx.SaveChangesAsync();
                return ship;
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpPatch(Routes.V1.Routes.Ships.Update)]
        public async Task<ActionResult<ALEvent>> UpdateShip(Guid id, [FromBody] Ship ship)
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

        [HttpDelete(Routes.V1.Routes.Ships.Delete)]
        public async Task<ActionResult<Ship>> DeleteShip(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships.AnyAsync(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships
                        .Include(s => s.BaseStats).Include(s => s.Level100Stats).Include(s => s.Level120Stats)
                        .Include(s => s.Level100RetrofitStats).Include(s => s.Level120RetrofitStats)
                        .Include(s => s.Skins)
                        .Single(ship => ship.Id == id);
                    ctx.Ships.Remove(selectedShip);

                    ctx.Remove(selectedShip.BaseStats);
                    ctx.Remove(selectedShip.Level100Stats);
                    ctx.Remove(selectedShip.Level120Stats);
                    ctx.Remove(selectedShip.Level100RetrofitStats);
                    ctx.Remove(selectedShip.Level120RetrofitStats);
                    ctx.RemoveRange(selectedShip.Skins);

                    await ctx.SaveChangesAsync();
                    return selectedShip;
                }
                else
                {
                    return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}