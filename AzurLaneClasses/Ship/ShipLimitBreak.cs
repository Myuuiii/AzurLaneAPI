using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipLimitBreak
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public IEnumerable<String> First { get; set; } = new List<String>();
        public IEnumerable<String> Second { get; set; } = new List<String>();
        public IEnumerable<String> Third { get; set; } = new List<String>();
    }
}