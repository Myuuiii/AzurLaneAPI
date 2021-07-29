using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipMisc
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public ShipArtist Artist { get; set; } = null;
        public ShipPixiv Pixiv { get; set; } = null;
        public ShipTwitter Twitter { get; set; } = null;
        public ShipWeb Web { get; set; } = null;
        public ShipVoiceActor VoiceActor { get; set; } = null;
    }
}