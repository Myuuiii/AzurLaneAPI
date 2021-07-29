using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipArtist
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
    }
}