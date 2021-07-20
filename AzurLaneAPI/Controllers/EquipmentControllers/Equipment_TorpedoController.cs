using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers.EquipmentControllers
{
    public class Equipment_TorpedoController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Equipment.Torpedoes.GetAll)]
        public async Task<ActionResult<List<Object>>> GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet(Routes.V1.Routes.Equipment.Torpedoes.GetId)]
        public async Task<ActionResult<Object>> GetId(Guid id)
        {
            return StatusCode(501);
        }

        [HttpPost(Routes.V1.Routes.Equipment.Torpedoes.Create)]
        public async Task<ActionResult<Object>> Create([FromBody] Object torpedo)
        {
            return StatusCode(501);
        }

        [HttpPatch(Routes.V1.Routes.Equipment.Torpedoes.Update)]
        public async Task<ActionResult<Object>> Update(Guid id, [FromBody] Object torpedo)
        {
            return StatusCode(501);
        }

        [HttpDelete(Routes.V1.Routes.Equipment.Torpedoes.Delete)]
        public async Task<ActionResult<Object>> Delete(Guid id)
        {
            return StatusCode(501);
        }
    }
}