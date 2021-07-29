using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipLimitBreaks
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public IEnumerable<String> LimitBreaks { get; set; } = new List<String>();
    }
}