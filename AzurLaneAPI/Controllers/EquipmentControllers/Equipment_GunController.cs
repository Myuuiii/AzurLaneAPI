using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_GunController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.Guns.GetAll)]
        public async Task<ActionResult<List<Object>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet(Routes.V1.Routes.Equipment.Guns.GetId)]
        public async Task<ActionResult<Object>> GetId(Guid id)
        {
            return StatusCode(501);
        }

        [HttpPost(Routes.V1.Routes.Equipment.Guns.Create)]
        public async Task<ActionResult<Object>> Create([FromBody] Object gun)
        {
            return StatusCode(501);
        }

        [HttpPatch(Routes.V1.Routes.Equipment.Guns.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody] Object gun)
        {
            return StatusCode(501);
        }

        [HttpDelete(Routes.V1.Routes.Equipment.Guns.Delete)]
        public async Task<ActionResult<Object>> Delete(Guid id)
        {
            return StatusCode(501);
        }
    }
}