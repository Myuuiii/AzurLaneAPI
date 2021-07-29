using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipConstruction
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String ConstructionTime { get; set; }
        public ConstructionAvailability Availability { get; set; }
    }

    public class ConstructionAvailability
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String Light { get; set; }
        public String Heavy { get; set; }
        public String Special { get; set; }
        public String Limited { get; set; }
        public String Exchange { get; set; }
    }
}