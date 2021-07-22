using System;

namespace AzurLaneClasses.Equipment
{
    public class SubmarineTorpedo
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }

        public String TorpedoPower { get; set; }
        public String NumberOfTorpedoes { get; set; }
        public Int32 DamagerPerTorpedo { get; set; }
        public Double Reload { get; set; }

        public Double SurfaceDPS_LightArmor { get; set; }
        public Double SurfaceDPS_MediumArmor { get; set; }
        public Double SurfaceDPS_HeavyArmor { get; set; }
        
        public Int32 Range { get; set; }
        public Int32 Spread { get; set; }
        public Int32 Angle { get; set; }
        public String Attribute { get; set; }
        public Nation Nation { get; set; }
    }
}