using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_AntiSubmarineController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.AntiSubmarine.GetAll)]
        public async Task<ActionResult<List<Object>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet(Routes.V1.Routes.Equipment.AntiSubmarine.GetId)]
        public async Task<ActionResult<Object>> GetId(Guid id)
        {
            return StatusCode(501);
        }

        [HttpPost(Routes.V1.Routes.Equipment.AntiSubmarine.Create)]
        public async Task<ActionResult<Object>> Create([FromBody] Object antisubmarine)
        {
            return StatusCode(501);
        }

        [HttpPatch(Routes.V1.Routes.Equipment.AntiSubmarine.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody] Object antisubmarine)
        {
            return StatusCode(501);
        }

        [HttpDelete(Routes.V1.Routes.Equipment.AntiSubmarine.Delete)]
        public async Task<ActionResult<Object>> Delete(Guid id)
        {
            return StatusCode(501);
        }
    }
}