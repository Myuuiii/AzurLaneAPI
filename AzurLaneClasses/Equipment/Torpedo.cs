using System;

namespace AzurLaneClasses.Equipment
{
    public class Torpedo : SubmarineTorpedo
    {
        public Double PreloadDPS_LightArmor { get; set; }
        public Double PreloadDPS_MediumArmor { get; set; }
        public Double PreloadDPS_HeavyArmor { get; set; }
    }
}