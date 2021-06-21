using System;

namespace AzurLaneClasses
{
    public class ALEvent
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime? JP_Period { get; set; }
        public DateTime? CN_Period { get; set; }
        public DateTime? EN_Period { get; set; }
        public String Notes { get; set; }
    }
}