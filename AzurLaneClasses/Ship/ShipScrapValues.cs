using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipScrapValues
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public Int32 Coins { get; set; }
        public Int32 Oil { get; set; }
        public Int32 Medals { get; set; }
    }
}