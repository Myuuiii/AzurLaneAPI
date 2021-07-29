using System;
using System.ComponentModel.DataAnnotations;
using AzurLaneClasses.Import;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    /// <summary>
    /// A ship's statistics
    /// </summary>
    public class ShipStats
    {
        public ShipStats() { }
        public ShipStats(BaseStats stats)
        {

            this.Luck = String.IsNullOrEmpty(stats.luck) ? 0 : Convert.ToInt32(stats.luck);
            this.Armor = stats.armor;
            this.Speed = String.IsNullOrEmpty(stats.speed) ? 0 : Convert.ToInt32(stats.speed);
            this.Health = String.IsNullOrEmpty(stats.health) ? 0 : Convert.ToInt32(stats.health);
            this.Firepower = String.IsNullOrEmpty(stats.firepower) ? 0 : Convert.ToInt32(stats.firepower);
            this.AntiAir = String.IsNullOrEmpty(stats.antiair) ? 0 : Convert.ToInt32(stats.antiair);
            this.Torpedo = String.IsNullOrEmpty(stats.torpedo) ? 0 : Convert.ToInt32(stats.torpedo);
            this.Evasion = String.IsNullOrEmpty(stats.evasion) ? 0 : Convert.ToInt32(stats.evasion);
            this.Aviation = String.IsNullOrEmpty(stats.aviation) ? 0 : Convert.ToInt32(stats.aviation);
            this.OilConsumption = String.IsNullOrEmpty(stats.oilConsumption) ? 0 : Convert.ToInt32(stats.oilConsumption);
            this.Reload = String.IsNullOrEmpty(stats.reload) ? 0 : Convert.ToInt32(stats.reload);
            this.AntiSubmarine = String.IsNullOrEmpty(stats.antisubmarineWarfare) ? 0 : Convert.ToInt32(stats.antisubmarineWarfare);
            this.Oxygen = String.IsNullOrEmpty(stats.oxygen) ? 0 : Convert.ToInt32(stats.oxygen);
            this.Ammunition = String.IsNullOrEmpty(stats.ammunition) ? 0 : Convert.ToInt32(stats.ammunition);
            this.Accuracy = String.IsNullOrEmpty(stats.accuracy) ? 0 : Convert.ToInt32(stats.accuracy);
            this.HuntingRange = stats.huntingRange;
        }


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