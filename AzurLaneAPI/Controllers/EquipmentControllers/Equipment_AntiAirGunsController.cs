using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_AntiAirGunsController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.AntiAirGuns.GetAll)]
        public async Task<ActionResult<List<Object>>> GetAll()
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

        [HttpGet(Routes.V1.Routes.Equipment.AntiAirGuns.GetId)]
        public async Task<ActionResult<Object>> GetById(string id)
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

        [HttpPost(Routes.V1.Routes.Equipment.AntiAirGuns.Create)]
        public async Task<ActionResult<Object>> Create([FromBody]Object antiair)
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

        [HttpPatch(Routes.V1.Routes.Equipment.AntiAirGuns.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody]Object antiair)
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

        [HttpDelete(Routes.V1.Routes.Equipment.AntiAirGuns.Delete)]
        public async Task<ActionResult<Object>> Delete(Guid id)
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