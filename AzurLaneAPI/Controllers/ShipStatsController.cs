using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class ShipStatsController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.GetAll)]
        public async Task<ActionResult<List<ShipStats>>> GetShipStats()
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

        [HttpGet(Routes.V1.Routes.Ships.ShipStats.GetId)]
        public async Task<ActionResult<ShipStats>> GetShipStat(Guid statsId)
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.Create)]
        public async Task<ActionResult<ShipStats>> CreateShipStat(string shipId)
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.Update)]
        public async Task<ActionResult<ShipStats>> UpdateShipStat(Guid statsId, [FromBody] ShipStats shipStats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.Delete)]
        public async Task<ActionResult<ShipStats>> DeleteShipStat(Guid statsId)
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
    }
}