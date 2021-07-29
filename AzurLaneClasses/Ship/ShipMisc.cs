using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipMisc
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public ShipArtist Artist { get; set; } = new ShipArtist();
        public ShipPixiv Pixiv { get; set; } = new ShipPixiv();
        public ShipTwitter Twitter { get; set; } = new ShipTwitter();
        public ShipWeb Web { get; set; } = new ShipWeb();
        public ShipVoiceActor VoiceActor { get; set; } = new ShipVoiceActor();
    }
}