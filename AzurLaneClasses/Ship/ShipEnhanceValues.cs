using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipEnhanceValues
    {
        [JsonIgnore] public Guid Id { get; set; }
        public Int32 Firepower { get; set; }
        public Int32 Torpedo { get; set; }
        public Int32 Aviation { get; set; }
        public Int32 Reload { get; set; }
    }
}