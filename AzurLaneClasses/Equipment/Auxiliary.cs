using System;

namespace AzurLaneClasses.Equipment
{
    public class Auxiliary
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }
        public Int32 Stars { get; set; }
        public Int32 Health { get; set; }
        public Int32 Firepower { get; set; }
        public Int32 AntiAir { get; set; }
        public Int32 Torpedo { get; set; }
        public Int32 Aviation { get; set; }
        public Int32 Reload { get; set; }
        public Int32 Evasion { get; set; }
        public Int32 AntiSubmarine { get; set; }
        public Int32 Oxygen { get; set; }
        public Int32 Accuracy { get; set; }
        public Int32 Speed { get; set; }
        public String Notes { get; set; }
    }
}