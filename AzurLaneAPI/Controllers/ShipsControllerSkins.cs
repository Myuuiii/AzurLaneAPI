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
        [HttpGet(Routes.V1.Routes.Ships.Skins.GetAll)]
        public async Task<ActionResult<List<ShipSkin>>> GetAllSkinsAsync(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.Id == id))
                {
                    var ship = ctx.Ships.Include(s => s.Skins).Single(s => s.Id == id);
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

        [HttpGet(Routes.V1.Routes.Ships.Skins.GetId)]
        public async Task<ActionResult<ShipSkin>> GetSkinByIdAsync(Guid id, Guid skinId)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.Id == id))
                {
                    var ship = ctx.Ships.Include(s => s.Skins).Single(s => s.Id == id);
                    if (ship.Skins.Any(s => s.Id == skinId))
                    {
                        return ship.Skins.Single(s => s.Id == skinId);
                    }
                    else
                    {
                        return StatusCode(404, "(Ship Skin Entity) " + Errors.V1.Errors.X400.ResourceNotFound);
                    }
                }
                else
                {
                    return StatusCode(404, "(Ship Entity)" + Errors.V1.Errors.X400.ResourceNotFound);
                }
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpPost(Routes.V1.Routes.Ships.Skins.Create)]
        public async Task<ActionResult<ShipSkin>> CreateSkinAsync(Guid id, [FromBody] ShipSkin skin)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.Id == id))
                {
                    var ship = ctx.Ships.Include(s => s.Skins).Single(s => s.Id == id);
                    ship.Skins.Add(skin);
                    await ctx.SaveChangesAsync();
                    return skin;
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

        [HttpDelete(Routes.V1.Routes.Ships.Skins.Delete)]
        public async Task<ActionResult<ShipSkin>> DeleteSkinAsync(Guid id, Guid skinId)
        {
            try
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(s => s.Id == id))
                {
                    var ship = ctx.Ships.Include(s => s.Skins).Single(s => s.Id == id);
                    if (ship.Skins.Any(s => s.Id == skinId))
                    {
                        ship.Skins.Remove(ship.Skins.Single(s => s.Id == skinId));
                        await ctx.SaveChangesAsync();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(404, "(Ship Skin Entity) " + Errors.V1.Errors.X400.ResourceNotFound);
                    }
                }
                else
                {
                    return StatusCode(404, "(Ship Entity)" + Errors.V1.Errors.X400.ResourceNotFound);
                }
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}