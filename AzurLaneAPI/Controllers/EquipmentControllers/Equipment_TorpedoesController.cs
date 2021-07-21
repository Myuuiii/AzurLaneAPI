using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_TorpedoesController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.Torpedoes.GetAll)]
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

        [HttpGet(Routes.V1.Routes.Equipment.Torpedoes.GetId)]
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

        [HttpPost(Routes.V1.Routes.Equipment.Torpedoes.Create)]
        public async Task<ActionResult<Object>> Create([FromBody]Object torpedo)
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

        [HttpPatch(Routes.V1.Routes.Equipment.Torpedoes.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody]Object torpedo)
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

        [HttpDelete(Routes.V1.Routes.Equipment.Torpedoes.Delete)]
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