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
    public partial class ShipsController : Controller
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
                    .Include(s => s.Skins).Include(s => s.DefaultSkin)
                    .Include(s => s.Skills)
                    .Include(s => s.LimitBreaks)
                    .Include(s => s.Gallery)
                    .Include(s => s.EquipSlot1).Include(s => s.EquipSlot2).Include(s => s.EquipSlot3)
                    .Include(s => s.EnhanceValue).Include(s => s.ScrapValue).Include(s => s.Construction)
                    .Include(s => s.Misc)
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
                        .Include(s => s.Skins).Include(s => s.DefaultSkin)
                        .Include(s => s.Skills)
                        .Include(s => s.LimitBreaks)
                        .Include(s => s.Gallery)
                        .Include(s => s.EquipSlot1).Include(s => s.EquipSlot2).Include(s => s.EquipSlot3)
                        .Include(s => s.EnhanceValue).Include(s => s.ScrapValue).Include(s => s.Construction)
                        .Include(s => s.Misc)
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
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();
                
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                ship.Id = Guid.NewGuid();
                ctx.Ships.Add(ship);
                await ctx.SaveChangesAsync();
                return ship;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships.AnyAsync(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships
                        .Include(s => s.BaseStats).Include(s => s.Level100Stats).Include(s => s.Level120Stats)
                        .Include(s => s.Level100RetrofitStats).Include(s => s.Level120RetrofitStats)
                        .Include(s => s.Skins).Include(s => s.DefaultSkin)
                        .Include(s => s.Skills)
                        .Include(s => s.LimitBreaks)
                        .Include(s => s.Gallery)
                        .Include(s => s.EquipSlot1).Include(s => s.EquipSlot2).Include(s => s.EquipSlot3)
                        .Include(s => s.EnhanceValue).Include(s => s.ScrapValue).Include(s => s.Construction)
                        .Include(s => s.Misc)
                        .Single(ship => ship.Id == id);

                    ctx.Remove(selectedShip);
                    if (selectedShip.BaseStats != null) ctx.Remove(selectedShip.BaseStats);
                    if (selectedShip.Level100Stats != null) ctx.Remove(selectedShip.Level100Stats);
                    if (selectedShip.Level120Stats != null) ctx.Remove(selectedShip.Level120Stats);
                    if (selectedShip.Level100RetrofitStats != null) ctx.Remove(selectedShip.Level100RetrofitStats);
                    if (selectedShip.Level120RetrofitStats != null) ctx.Remove(selectedShip.Level120RetrofitStats);
                    if (selectedShip.Skins != null) ctx.RemoveRange(selectedShip.Skins);

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
