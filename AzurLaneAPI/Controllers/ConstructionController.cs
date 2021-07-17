using System;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class ConstructionController : ControllerBase
    {
        [HttpGet(Routes.V1.Routes.Construction.GetLightPool)]
        public ActionResult<ConstructionPool> GetLightPool()
        {
            try
            {
                return new ConstructionPool(
                    coins: 600,
                    wisdomCubes: 1,
                    cV: false,
                    cVL: true,
                    dD: true,
                    cL: true,
                    cA: false,
                    bM: false,
                    bC: false,
                    bB: false,
                    aR: true,
                    sS: false
                );
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Construction.GetHeavyPool)]
        public ActionResult<ConstructionPool> GetHeavypool()
        {
            try
            {
                return new ConstructionPool(
                    coins: 1500,
                    wisdomCubes: 2,
                    cV: false,
                    cVL: false,
                    dD: false,
                    cL: true,
                    cA: true,
                    bM: true,
                    bC: true,
                    bB: true,
                    aR: false,
                    sS: false
                );
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Construction.GetSpecialPool)]
        public ActionResult<ConstructionPool> GetSpecialPool()
        {
            try
            {
                return new ConstructionPool(
                    coins: 1500,
                    wisdomCubes: 2,
                    cV: true,
                    cVL: true,
                    dD: false,
                    cL: true,
                    cA: true,
                    bM: false,
                    bC: false,
                    bB: false,
                    aR: true,
                    sS: true
                );
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }

        [HttpGet(Routes.V1.Routes.Construction.GetLimitedPool)]
        public ActionResult<String> GetLimitedPool()
        {
            try
            {
                return "This pool is based on one of the 3 other pools: light, heavy and special";
            }
            catch
            {
                return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
            }
        }
    }
}