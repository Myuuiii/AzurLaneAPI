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
	public class ShipGalleryController : Controller
	{
        /// <summary>
        /// Retrieve all the gallery items
        /// </summary>
		[HttpGet(Routes.V1.Routes.Ships.ShipGallery.GetAll)]
		public async Task<ActionResult<List<ShipGalleryItem>>> GetAll()
		{
			try
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
				List<ShipGalleryItem> galleryItems = new List<ShipGalleryItem>();
				foreach (var ship in ctx.Ships.Include(s => s.Gallery))
				{
					galleryItems.AddRange(ship.Gallery);
				}
				return galleryItems;
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}


        /// <summary>
        /// Retrieve the gallery of a ship by ship Id
        /// </summary>
        /// <param name="id">Ship Id</param>
		[HttpGet(Routes.V1.Routes.Ships.ShipGallery.GetAllByShipId)]
		public async Task<ActionResult<List<ShipGalleryItem>>> GetAllById(String id)
		{
			try
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
				if (ctx.Ships.Any(s => s.ShipId == id))
				{
					return ctx.Ships.Include(s => s.Gallery).Single(s => s.ShipId == id).Gallery;
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
        /// Retrieve the gallery of a ship by ship name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipGallery.GetAllByShipName)]
		public async Task<ActionResult<List<ShipGalleryItem>>> GetAllByName(String name)
		{
			try
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
				if (ctx.Ships.Any(s => s.Name == name))
				{
					return ctx.Ships.Include(s => s.Gallery).Single(s => s.Name == name).Gallery;
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