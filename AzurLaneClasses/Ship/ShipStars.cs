using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipStars
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String Stars { get; set; }
        public Int32 Count { get; set; }
    }
}