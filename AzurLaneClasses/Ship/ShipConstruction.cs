using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipConstruction
    {
        [JsonIgnore] public Guid Id { get; set; }
        public TimeSpan ConstructionTime { get; set; }
        public ConstructionAvailability Availability { get; set; }
    }

    public class ConstructionAvailability
    {
        [JsonIgnore] public Guid Id { get; set; }
        public Boolean Light { get; set; }
        public Boolean Heavy { get; set; }
        public Boolean Aviation { get; set; }
        public String Limited { get; set; }
        public String Exchange { get; set; }
    }
}