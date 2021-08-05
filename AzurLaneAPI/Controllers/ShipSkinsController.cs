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
    public class ShipSkinsController : Controller
    {
        private AzurLaneDbContext _context;

		public ShipSkinsController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieve all the ship skins
		/// </summary>
		/// <param name="page">Page Number</param>
		/// <param name="itemsPerPage">Items to display per page, limited to 20 without API key</param>
		[HttpGet(Routes.V1.Routes.Ships.ShipSkins.GetAll)]
        public async Task<ActionResult<List<ShipSkin>>> GetAll(Int32? page = null, Int32? itemsPerPage = null)
        {
            try 
            {
                if (page == null && itemsPerPage == null) 
                {
                    if (!Helpers.Authenticate(HttpContext)) return Unauthorized();
                    return _context.ShipSkins.ToList();
                }
                else if (page == null && itemsPerPage != null) return BadRequest("You need to define a page number");
                else if (page != null && itemsPerPage == null) return BadRequest("You need to define the amount of skins per page");
                else if (page != null && itemsPerPage != null)
                {

                    if (itemsPerPage > 20)
                    {
                        if (!Helpers.Authenticate(HttpContext)) return Unauthorized("You need an API key to retrieve more than 20 skins at a time");
                    }

                    var skip = (page - 1) * itemsPerPage;

                    HttpContext.Response.Headers.Add("TotalPages", Convert.ToString(_context.Ships.ToArray().Length / itemsPerPage));
                    HttpContext.Response.Headers.Add("CurrentPage", Convert.ToString(page));
                    return await _context.ShipSkins
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
        /// Retrieve all the skins of a ship 
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipSkins.GetAllByShipId)]
        public async Task<ActionResult<List<ShipSkin>>> GetAllSkinsAsync(String id)
        {
            try
            {
                if (_context.Ships.Any(s => s.ShipId == id))
                {
                    var ship = _context.Ships
                        .Include(s => s.Skins)
                        .Single(s => s.ShipId == id);

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


        /// <summary>
        /// Retrieve all the skins of a ship using the name of the ship
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipSkins.GetAllByShipName)]
        public async Task<ActionResult<List<ShipSkin>>> GetAllSkinsByShipNameAsync(String name)
        {
            try
            {
                if (_context.Ships.Any(s => s.Name == name))
                {
                    var ship = _context.Ships
                        .Include(s => s.Skins)
                        .Single(s => s.Name == name);

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
    }
}