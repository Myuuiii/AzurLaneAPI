using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses.Ship;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class ShipStatsController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Ships.ShipStats.GetStats)]
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

        [HttpGet(Routes.V1.Routes.Ships.ShipStats.GetStatsById)]
        public async Task<ActionResult<ShipStats>> GetShipStatsById(Guid statsId)
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

        [HttpPost(Routes.V1.Routes.Ships.ShipStats.CreateStats)]
        public async Task<ActionResult<ShipStats>> CreateShipStats(string shipId)
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

        [HttpPatch(Routes.V1.Routes.Ships.ShipStats.UpdateStats)]
        public async Task<ActionResult<ShipStats>> UpdateShipStats(Guid statsId, [FromBody] ShipStats shipStats)
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

        [HttpDelete(Routes.V1.Routes.Ships.ShipStats.DeleteStats)]
        public async Task<ActionResult<ShipStats>> DeleteShipStats(Guid statsId)
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