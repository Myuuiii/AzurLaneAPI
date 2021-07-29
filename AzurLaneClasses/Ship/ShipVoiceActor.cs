using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipVoiceActor
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Url { get; set; }
    }
}