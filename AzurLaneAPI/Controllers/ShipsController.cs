using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Import;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public partial class ShipsController : Controller
    {
        [HttpGet(Routes.V1.Routes.Ships.GetAll)]
        public async Task<ActionResult<List<Ship>>> GetShips(Int32? page = null, Int32? itemsPerPage = null)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (page == null && itemsPerPage == null)
                {
                    if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                    return await ctx.Ships
                    .Include(s => s.Stars)
                    .Include(s => s.DefaultSkin)
                    .Include(s => s.Skins)
                    .Include(s => s.Skills)
                    .Include(s => s.LimitBreaks)
                    .Include(s => s.Gallery)
                    .Include(s => s.EquippableSlots)
                    .Include(s => s.BaseStats)
                    .Include(s => s.Level100Stats)
                    .Include(s => s.Level120Stats)
                    .Include(s => s.Level100RetrofitStats)
                    .Include(s => s.Level120RetrofitStats)
                    .Include(s => s.EnhanceValue)
                    .Include(s => s.ScrapValue)
                    .Include(s => s.Construction)
                    .Include(s => s.Artist)
                    .Include(s => s.Pixiv)
                    .Include(s => s.Twitter)
                    .Include(s => s.Web)
                    .Include(s => s.VoiceActor)
                        .ToListAsync();
                }
                else if (page == null && itemsPerPage != null)
                {
                    return BadRequest("You need to define a page number");
                }
                else if (page != null && itemsPerPage == null)
                {
                    return BadRequest("You need to define the amount of ships per page");
                }
                else if (page != null && itemsPerPage != null)
                {

                    if (itemsPerPage > 20)
                    {
                        if (!Helpers.Authenticate(HttpContext)) return Unauthorized("You need an API key to retrieve more than 20 ships at a time");
                    }

                    var skip = (page - 1) * itemsPerPage;

                    HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(ctx.Ships.ToArray().Length / itemsPerPage));
                    HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
                    return await ctx.Ships
                    .Include(s => s.Stars)
                    .Include(s => s.DefaultSkin)
                    .Include(s => s.Skins)
                    .Include(s => s.Skills)
                    .Include(s => s.LimitBreaks)
                    .Include(s => s.Gallery)
                    .Include(s => s.EquippableSlots)
                    .Include(s => s.BaseStats)
                    .Include(s => s.Level100Stats)
                    .Include(s => s.Level120Stats)
                    .Include(s => s.Level100RetrofitStats)
                    .Include(s => s.Level120RetrofitStats)
                    .Include(s => s.EnhanceValue)
                    .Include(s => s.ScrapValue)
                    .Include(s => s.Construction)
                    .Include(s => s.Artist)
                    .Include(s => s.Pixiv)
                    .Include(s => s.Twitter)
                    .Include(s => s.Web)
                    .Include(s => s.VoiceActor)
                    .Skip((Int32)skip).Take((Int32)itemsPerPage)
                        .ToListAsync();
                }
                else
                {
                    return BadRequest("Something was not formatted correctly in your request");
                }

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
                if (await ctx.Ships.AnyAsync(ship => ship.Id == id))
                {
                    Ship ship = await ctx.Ships
                    .Include(s => s.Stars)
                    .Include(s => s.DefaultSkin)
                    .Include(s => s.Skins)
                    .Include(s => s.Skills)
                    .Include(s => s.LimitBreaks)
                    .Include(s => s.Gallery)
                    .Include(s => s.EquippableSlots)
                    .Include(s => s.BaseStats)
                    .Include(s => s.Level100Stats)
                    .Include(s => s.Level120Stats)
                    .Include(s => s.Level100RetrofitStats)
                    .Include(s => s.Level120RetrofitStats)
                    .Include(s => s.EnhanceValue)
                    .Include(s => s.ScrapValue)
                    .Include(s => s.Construction)
                    .Include(s => s.Artist)
                    .Include(s => s.Pixiv)
                    .Include(s => s.Twitter)
                    .Include(s => s.Web)
                    .Include(s => s.VoiceActor)
                        .SingleAsync(ship => ship.Id == id);
                    return ship;
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
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpPut(Routes.V1.Routes.Ships.Import)]
        public async Task<ActionResult> ImportShips([FromBody] List<ShipDataImportModel> shipDataImportModels)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                foreach (ShipDataImportModel shipDataImportModel in shipDataImportModels)
                {
                    ctx.Add(new Ship(shipDataImportModel));
                }
                await ctx.SaveChangesAsync();
                return Ok();
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
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.Ships.AnyAsync(ship => ship.Id == id))
                {
                    Ship selectedShip = ctx.Ships
                        .Include(s => s.Stars)
                    .Include(s => s.DefaultSkin)
                    .Include(s => s.Skins)
                    .Include(s => s.Skills)
                    .Include(s => s.LimitBreaks)
                    .Include(s => s.Gallery)
                    .Include(s => s.EquippableSlots)
                    .Include(s => s.BaseStats)
                    .Include(s => s.Level100Stats)
                    .Include(s => s.Level120Stats)
                    .Include(s => s.Level100RetrofitStats)
                    .Include(s => s.Level120RetrofitStats)
                    .Include(s => s.EnhanceValue)
                    .Include(s => s.ScrapValue)
                    .Include(s => s.Construction)
                    .Include(s => s.Artist)
                    .Include(s => s.Pixiv)
                    .Include(s => s.Twitter)
                    .Include(s => s.Web)
                    .Include(s => s.VoiceActor)
                        .Single(ship => ship.Id == id);

                    ctx.Remove(selectedShip);
                    if (selectedShip.Stars != null) ctx.Remove(selectedShip.Stars);
                    if (selectedShip.DefaultSkin != null) ctx.Remove(selectedShip.DefaultSkin);
                    if (selectedShip.Skins != null) ctx.RemoveRange(selectedShip.Skins);
                    if (selectedShip.Skills != null) ctx.RemoveRange(selectedShip.Skills);
                    if (selectedShip.LimitBreaks != null) ctx.RemoveRange(selectedShip.LimitBreaks);
                    if (selectedShip.Gallery != null) ctx.RemoveRange(selectedShip.Gallery);
                    if (selectedShip.EquippableSlots != null) ctx.Remove(selectedShip.EquippableSlots);
                    if (selectedShip.BaseStats != null) ctx.Remove(selectedShip.BaseStats);
                    if (selectedShip.Level100Stats != null) ctx.Remove(selectedShip.Level100Stats);
                    if (selectedShip.Level120Stats != null) ctx.Remove(selectedShip.Level120Stats);
                    if (selectedShip.Level100RetrofitStats != null) ctx.Remove(selectedShip.Level100RetrofitStats);
                    if (selectedShip.Level120RetrofitStats != null) ctx.Remove(selectedShip.Level120RetrofitStats);
                    if (selectedShip.EnhanceValue != null) ctx.Remove(selectedShip.EnhanceValue);
                    if (selectedShip.ScrapValue != null) ctx.Remove(selectedShip.ScrapValue);
                    if (selectedShip.Construction != null) ctx.Remove(selectedShip.Construction);
                    if (selectedShip.Artist != null) ctx.Remove(selectedShip.Artist);
                    if (selectedShip.Pixiv != null) ctx.Remove(selectedShip.Pixiv);
                    if (selectedShip.Twitter != null) ctx.Remove(selectedShip.Twitter);
                    if (selectedShip.Web != null) ctx.Remove(selectedShip.Web);
                    if (selectedShip.VoiceActor != null) ctx.Remove(selectedShip.VoiceActor);

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
