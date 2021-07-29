using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipTwitter
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Url { get; set; }
    }
}