using System;

namespace AzurLaneClasses.Equipment
{
    public class AntiSub
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }
        public Int32 Stars { get; set; }
        public Int32 AntiSubmarine { get; set; }
        public Int32 Accuracy { get; set; }
        public Int32 Damage { get; set; }
        public Double Reload { get; set; }
        public Double DPS { get; set; }
        public Int32 Range { get; set; }
        public Int32 AoERadius { get; set; }
        public AntiSubmarineType Type { get; set; }
        public String Notes { get; set; }
    }
}