using System;

namespace AzurLaneClasses.Equipment
{
    public class Plane
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }

        public Int32 Aviation { get; set; }
        // public String Ordnance { get; set; } // * Not sure if this is needed
        // public String Guns {get; set;} // * Not sure if this is needed
        public Double Reload { get; set; }

        public Double SurfaceDPS_LightArmor { get; set; }
        public Double SurfaceDPS_MediumArmor { get; set; }
        public Double SurfaceDPS_HeavyArmor { get; set; }

        public Double AntiAir_DPS { get; set; }
        public Double AntiAir_Burst { get; set; }

        public Int32 Crash_Speed { get; set; }
        public Int32 Crash_Damage { get; set; }
        public Nation Nation { get; set; }
    }
}