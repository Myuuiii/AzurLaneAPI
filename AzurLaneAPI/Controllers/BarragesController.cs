using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AzurLaneAPI.Controllers
{
    public class BarragesController : Controller
    {
        /// <summary>
        /// Get all the barrages
        /// </summary>
        [HttpGet(Routes.V1.Routes.Barrages.GetAll)]
        public async Task<ActionResult<List<Barrage>>> GetAll(Int32? page = null, Int32? itemsPerPage = null)
        {
            try 
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();

                if (page == null && itemsPerPage == null) 
                {
                    if (!Helpers.Authenticate(HttpContext)) return Unauthorized();
                    return ctx.Barrages.Include(b => b.Rounds).ToList();
                }
                else if (page == null && itemsPerPage != null) return BadRequest("You need to define a page number");
                else if (page != null && itemsPerPage == null) return BadRequest("You need to define the amount of barrages per page");
                else if (page != null && itemsPerPage != null)
                {

                    if (itemsPerPage > 20)
                    {
                        if (!Helpers.Authenticate(HttpContext)) return Unauthorized("You need an API key to retrieve more than 20 barrages at a time");
                    }

                    var skip = (page - 1) * itemsPerPage;

                    HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(ctx.Ships.ToArray().Length / itemsPerPage));
                    HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
                    return await ctx.Barrages
                        .Include(b => b.Rounds)
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

        /// <summary>
        /// Get a barrage by id
        /// </summary>
        [HttpGet(Routes.V1.Routes.Barrages.GetId)]
        public async Task<ActionResult<Barrage>> Get(string id)
        {
            try 
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Barrages.Any(b => b.Id == id))
                {
                    return await ctx.Barrages.SingleAsync(b => b.Id == id);
                }
                else 
                {
                    return StatusCode(404, Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
                }
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        
        /// <summary>
        /// Get barrages by ship name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Barrages.GetAllByName)]
        public async Task<ActionResult<List<Barrage>>> GetAllByName(string name)
        {
            try 
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                List<Barrage> barrages = new List<Barrage>();
                foreach (var barrage in ctx.Barrages.Include(b => b.Rounds))
                {
                    foreach (var shipName in barrage.Ships)
                    {
                        if (shipName.ToLower() == name.ToLower()) barrages.Add(barrage);
                    }
                }

                if (barrages.Any())
                {
                    return barrages;
                }
                else 
                {
                    return StatusCode(404, Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
                }
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }


        /// <summary>
        /// Import Barrages (Developer Only)
        /// </summary>
        [HttpPut(Routes.V1.Routes.Barrages.Import)]
        public async Task<ActionResult<Barrage>> Import()
        {
            try 
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                List<BarrageDataImportModel> barrageDataImportModels = JsonConvert.DeserializeObject<List<BarrageDataImportModel>>(new WebClient().DownloadString("https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/dist/barrage.json").Replace("https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/", "http://cdn.mutedevs.nl/azurlaneapi/"));
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                ctx.Barrages.RemoveRange(ctx.Barrages.Include(b => b.Rounds));
                ctx.SaveChanges();

                foreach (BarrageDataImportModel barrageDataImportModel in barrageDataImportModels)
                {
                    ctx.Add(new Barrage(barrageDataImportModel));
                }
                await ctx.SaveChangesAsync();
                return Ok("API Data was successfully updated");
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}