using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    /// <summary>
    /// A ship's statistics
    /// </summary>
    public class ShipStats
    {
        public ShipStats() { }

        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public Int32 Luck { get; set; }
        public String Armor { get; set; }
        public Int32 Speed { get; set; }
        public Int32 Health { get; set; }
        public Int32 Firepower { get; set; }
        public Int32 AntiAir { get; set; }
        public Int32 Torpedo { get; set; }
        public Int32 Evasion { get; set; }
        public Int32 Aviation { get; set; }
        public Int32 OilConsumption { get; set; }
        public Int32 Reload { get; set; }
        public Int32 AntiSubmarine { get; set; }
        public Int32 Oxygen { get; set; }
        public Int32 Ammunition { get; set; }
        public Int32 Accuracy { get; set; }
        public String HuntingRange { get; set; } = "";
    }
}