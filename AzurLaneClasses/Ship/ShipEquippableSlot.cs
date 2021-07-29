using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipEquippableSlot
    {
        [JsonIgnore] public Guid Id { get; set; }
        public Int32 MaxEfficiency { get; set; }
        public Int32 MinEfficiency { get; set; }
        public String Type { get; set; }
        public Int32 Max { get; set; }
    }
}