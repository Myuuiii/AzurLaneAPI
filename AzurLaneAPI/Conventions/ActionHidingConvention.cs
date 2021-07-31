using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AzurLaneAPI.Conventions
{
    public class ActionHidingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            List<string> hiddenControllers = new List<string>()
            {
                "Docs",
                "Equipment_AntiAirGuns",
                "Equipment_AntiSubmarine",
                "Equipment_Auxiliary",
                "Equipment_BattleshipGuns",
                "Equipment_Cargo",
                "Equipment_DestroyerGuns",
                "Equipment_DiveBomberPlanes",
                "Equipment_FighterPlanes",
                "Equipment_HeavyCruiserGuns",
                "Equipment_LargeCruiserGuns",
                "Equipment_LightCruiserGuns",
                "Equipment_Seaplanes",
                "Equipment_SubmarineTorpedoes",
                "Equipment_Torpedoes",
                "Equipment_TorpedoBomberPlanes"
            };

            if(hiddenControllers.Contains(action.Controller.ControllerName))
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }
}