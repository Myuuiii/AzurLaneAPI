using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AzurLaneAPI.Controllers
{
    public class BarragesController : Controller
    {   
        private AzurLaneDbContext _context;

		public BarragesController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get all the barrages
		/// </summary>
		[HttpGet(Routes.V1.Routes.Barrages.GetAll)]
        public async Task<ActionResult<List<Barrage>>> GetAll(Int32? page = null, Int32? itemsPerPage = null)
        {
            try 
            {
                if (page == null && itemsPerPage == null) 
                {
                    return _context.Barrages.Include(b => b.Rounds).ToList();
                }
                else if (page == null && itemsPerPage != null) return BadRequest("You need to define a page number");
                else if (page != null && itemsPerPage == null) return BadRequest("You need to define the amount of barrages per page");
                else if (page != null && itemsPerPage != null)
                {
                    var skip = (page - 1) * itemsPerPage;

                    HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(_context.Ships.ToArray().Length / itemsPerPage));
                    HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
                    return await _context.Barrages
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
                if (_context.Barrages.Any(b => b.Id == id))
                {
                    return await _context.Barrages.SingleAsync(b => b.Id == id);
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
                List<Barrage> barrages = new List<Barrage>();
                foreach (var barrage in _context.Barrages.Include(b => b.Rounds))
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
        /// (Developer Only) Import barrages using scraper
        /// </summary>
        [HttpPut(Routes.V1.Routes.Barrages.ImportScraper)]
        public async Task<ActionResult> Import()
        {
            try 
            {
                if (!Helpers.Authenticate(HttpContext)) return Unauthorized();

                List<Barrage> importBarrages = Scrapers.BarragesScraper.GetBarrages();

                _context.Barrages.RemoveRange(_context.Barrages.Include(b => b.Rounds));
                _context.SaveChanges();

                _context.AddRange(importBarrages);

                await _context.SaveChangesAsync();
                return Ok("API Data was successfully updated");
            }
            catch 
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}