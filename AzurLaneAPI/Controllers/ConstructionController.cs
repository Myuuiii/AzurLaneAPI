using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public class ConstructionController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Construction.GetPools)]
        public async Task<ActionResult<List<ConstructionPool>>> GetPools()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.ConstructionPools.ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Construction.GetPool)]
        public async Task<ActionResult<ConstructionPool>> GetLightPool(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.ConstructionPools.AnyAsync(p => p.Name.ToLower() == id.ToLower()))
                {
                    return await ctx.ConstructionPools.SingleAsync(p => p.Name.ToLower() == id.ToLower());
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