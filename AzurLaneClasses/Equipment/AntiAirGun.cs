using System;

namespace AzurLaneClasses.Equipment
{
    public class AntiAirGun
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }

        public Int32 Firepower { get; set; }
        public Int32 AntiAir { get; set; }
        public Int32 Accuracy { get; set; }
        public Int32 Damage { get; set; }
        public Double Reload { get; set; }
        public Double AADPS { get; set; }
        public Int32 Range { get; set; }
        public String Nation { get; set; }
    }
}