using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipSkill
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String IconUrl { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Color { get; set; }
    }
}