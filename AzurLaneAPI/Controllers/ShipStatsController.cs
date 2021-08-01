using System;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
	public class ShipStatsController : Controller
	{
		/// <summary>
		/// Retrieve a ship's base stats
		/// </summary>
		/// <param name="id">Ship Id</param>
		[HttpGet(Routes.V1.Routes.Ships.ShipStats.Base)]
		public async Task<ActionResult<ShipStats>> GetBaseStats(String id)
		{
			try
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
				if (ctx.Ships.Any(ship => ship.ShipId == id))
				{
					return ctx.Ships
						.Include(s => s.BaseStats)
						.Single(ship => ship.ShipId == id).BaseStats;
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
		/// Retrieve a ship's base stats by name
		/// </summary>
		/// <param name="name">Ship Name</param>
		[HttpGet(Routes.V1.Routes.Ships.ShipStats.BaseName)]
		public async Task<ActionResult<ShipStats>> GetBaseStatsByName(String name)
		{
			try
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
				if (ctx.Ships.Any(ship => ship.Name == name))
				{
					return ctx.Ships
						.Include(s => s.BaseStats)
						.Single(ship => ship.Name == name).BaseStats;
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
        /// Retrieve a ship's level 100 retrofit stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100Retro)]
        public async Task<ActionResult<ShipStats>> GetLvl100RetrofitStats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level100RetrofitStats)
                        .Single(ship => ship.ShipId == id).Level100RetrofitStats;
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
        /// Retrieve a ship's level 100 retrofit stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100RetroName)]
        public async Task<ActionResult<ShipStats>> GetLvl100RetrofitStatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.Level100RetrofitStats)
                        .Single(ship => ship.Name == name).Level100RetrofitStats;
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
        /// Retrieve a ship's level 100 stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100)]
        public async Task<ActionResult<ShipStats>> GetLvl100Stats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.ShipId == id).Level100Stats;
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
        /// Retrieve a ship's level 100 stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl100Name)]
        public async Task<ActionResult<ShipStats>> GetLvl100StatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.Level100Stats)
                        .Single(ship => ship.Name == name).Level100Stats;
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
        /// Retrieve a ship's level 120 retrofit stats
        /// </summary>
        /// <param name="id">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl120Retro)]
        public async Task<ActionResult<ShipStats>> GetLvl120RetrofitStats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level120RetrofitStats)
                        .Single(ship => ship.ShipId == id).Level120RetrofitStats;
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
        /// Retrieve a ship's level 120 retrofit stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl120RetroName)]
        public async Task<ActionResult<ShipStats>> GetLvl120RetrofitStatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.Level120RetrofitStats)
                        .Single(ship => ship.Name == name).Level120RetrofitStats;
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
        /// Retrieve a ship's level 120 stats
        /// </summary>
        /// <param name="name">Ship Id</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl120)]
        public async Task<ActionResult<ShipStats>> GetLvl120Stats(String id)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.ShipId == id))
                {
                    return ctx.Ships
                        .Include(s => s.Level120Stats)
                        .Single(ship => ship.ShipId == id).Level120Stats;
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
        /// Retrieve a ship's level 120 stats by name
        /// </summary>
        /// <param name="name">Ship Name</param>
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.Lvl120Name)]
        public async Task<ActionResult<ShipStats>> GetLvl120StatsByName(String name)
        {
            try
            {
                AzurLaneDbContext ctx = new AzurLaneDbContext();
                if (ctx.Ships.Any(ship => ship.Name == name))
                {
                    return ctx.Ships
                        .Include(s => s.Level120Stats)
                        .Single(ship => ship.Name == name).Level120Stats;
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