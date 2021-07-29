using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipArtist
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
    }
}