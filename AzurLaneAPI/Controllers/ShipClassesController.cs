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
    public class ShipClassesController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Ships.ShipClasses.GetAll)]
        public async Task<ActionResult<List<ShipClass>>> GetAll()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.ShipClasses.ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Ships.ShipClasses.GetId)]
        public async Task<ActionResult<ShipClass>> GetById(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.ShipClasses.Any(x => x.Id == id))
                {
                    return await ctx.ShipClasses.SingleAsync(x => x.Id == id);
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

        [HttpGet(Routes.V1.Routes.Ships.ShipClasses.GetName)]
        public async Task<ActionResult<ShipClass>> GetByName(string name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.ShipClasses.Any(x => x.Name == name))
                {
                    return await ctx.ShipClasses.SingleAsync(x => x.Name == name);
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

        [HttpPost(Routes.V1.Routes.Ships.ShipClasses.Create)]
        public async Task<ActionResult<ShipClass>> Create([FromBody] ShipClass shipClass)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                ctx.ShipClasses.Add(shipClass);
                await ctx.SaveChangesAsync();
                return shipClass;
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpDelete(Routes.V1.Routes.Ships.ShipClasses.Delete)]
        public async Task<ActionResult<ShipClass>> Delete(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.ShipClasses.Any(x => x.Id == id))
                {
                    ctx.ShipClasses.Remove(ctx.ShipClasses.Single(x => x.Id == id));
                    await ctx.SaveChangesAsync();
                    return await ctx.ShipClasses.SingleAsync(x => x.Id == id);
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