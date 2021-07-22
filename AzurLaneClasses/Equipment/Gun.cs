using System;

namespace AzurLaneClasses.Equipment
{
    public class Gun
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }
        public Int32 Firepower { get; set; }
        public Int32 AntiAir { get; set; }

        public String Rounds { get; set; }
        public Double RoundsPerSecond { get; set; }

        public Int32 DamagePerShot { get; set; }
        public Int32 DamageCoefficient { get; set; }
        public Double VolleyTime { get; set; }
        public Double Reload { get; set; }

        public Double RawDPS { get; set; }
        public Double LightArmorDPS { get; set; }
        public Double MediumArmorDPS { get; set; }
        public Double HeavyArmorDPS { get; set; }

        public Int32 Range { get; set; }
        public Int32 Spread { get; set; }
        public Int32 Angle { get; set; }
        public String Attribute { get; set; }
        public AmmoType AmmoType { get; set; }
        public Nation Nation { get; set; }
    }
}