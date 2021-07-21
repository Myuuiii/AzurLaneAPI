using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_BattleshipGunsController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.BattleshipGuns.GetAll)]
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

        [HttpGet(Routes.V1.Routes.Equipment.BattleshipGuns.GetId)]
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

        [HttpPost(Routes.V1.Routes.Equipment.BattleshipGuns.Create)]
        public async Task<ActionResult<Object>> Create([FromBody]Object gun)
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

        [HttpPatch(Routes.V1.Routes.Equipment.BattleshipGuns.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody]Object gun)
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

        [HttpDelete(Routes.V1.Routes.Equipment.BattleshipGuns.Delete)]
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