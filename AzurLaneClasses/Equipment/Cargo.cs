using System;

namespace AzurLaneClasses.Equipment
{
    public class Cargo
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String IconUrl { get; set; }
        public Int32 Stars { get; set; }
        public Int32 Health { get; set; }
        public String Notes { get; set; }
    }
}