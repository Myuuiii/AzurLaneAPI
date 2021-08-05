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
        private AzurLaneDbContext _context;

		public ConstructionController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get all construction pools
		/// </summary>
		[HttpGet(Routes.V1.Routes.Construction.GetPools)]
        public async Task<ActionResult<List<ConstructionPool>>> GetPools()
        {
            try
            {
                return await _context.ConstructionPools.ToListAsync();
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        /// <summary>
        /// Get construction pool by id 
        /// </summary>
        [HttpGet(Routes.V1.Routes.Construction.GetPool)]
        public async Task<ActionResult<ConstructionPool>> GetPool(String id)
        {
            try
            {
                if (await _context.ConstructionPools.AnyAsync(p => p.Name.ToLower() == id.ToLower()))
                {
                    return await _context.ConstructionPools.SingleAsync(p => p.Name.ToLower() == id.ToLower());
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