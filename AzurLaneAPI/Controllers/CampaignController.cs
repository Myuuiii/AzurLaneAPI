using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
    public class CampaignController : ControllerBase
    {
        /// <summary>
        /// Get all the campaign levels
        /// </summary>
        [HttpGet(Routes.V1.Routes.Campaign.GetAll)]
        public async Task<ActionResult<List<CampaignLevel>>> GetLevels()
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                return await ctx.CampaignLevels.OrderBy(cl => cl.Chapter).ThenBy(cl => cl.Level).ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        /// <summary>
        /// Get a campaign level by id
        /// </summary>
        /// <param name="id">Level ID</param>
        [HttpGet(Routes.V1.Routes.Campaign.GetId)]
        public async Task<ActionResult<CampaignLevel>> GetLevel(Guid id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (await ctx.CampaignLevels.AnyAsync(cl => cl.Id == id))
                {
                    return await ctx.CampaignLevels.SingleAsync(cl => cl.Id == id);
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
        /// Get a campaign level by Chapter and Level Nr
        /// </summary>
        /// <param name="chapter">Chapter</param>
        /// <param name="level">Level Nr</param>
        [HttpGet(Routes.V1.Routes.Campaign.GetSelect)]
        public async Task<ActionResult<CampaignLevel>> GetSelectLevel(Int32 chapter, Int32 level)
        {
            try
            {
                if (chapter <= 13 && chapter > 0)
                {
                    if (level <= 4 && level >= 0)
                    {
                        AzurLaneDbContext ctx = new AzurLaneDbContext();
                        if (await ctx.CampaignLevels.AnyAsync(cl => cl.Chapter == chapter && cl.Level == level))
                        {
                            return ctx.CampaignLevels.Single(cl => cl.Chapter == chapter && cl.Level == level);
                        }
                        else
                        {
                            return NotFound(Errors.V1.Errors.X400.ResourceNotFound);
                        }
                    }
                    else
                    {
                        return BadRequest("You can only select level 0 through 4 in a chapter");
                    }
                }
                else
                {
                    return BadRequest("There are 13 chapters");
                }

            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}