using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipStars
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String Stars { get; set; }
        public Int32 Count { get; set; }
    }
}