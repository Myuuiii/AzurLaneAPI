using System;
using System.ComponentModel.DataAnnotations;

namespace AzurLaneClasses.Ship
{
    public class MinimalShip
    {
        // * Identity Properties
        [Key] public Guid Id { get; set; }

        // * Properties
        [Required] public String ShipId { get; set; }
        [Required] public String Name { get; set; }
        [Required] public ShipRarity Rarity { get; set; }
        [Required] public Nation Nation { get; set; }
        [Required] public ShipType Type { get; set; }
        public Boolean HasLive2DModel { get; set; } = false;

        // ? Creator Information
        [Required] public String Artist { get; set; }
        [Required] public String VoiceActor { get; set; }

        // ? Images
        [Required] public String IconImage { get; set; }
        [Required] public String ThumbnailImage { get; set; }
        [Required] public String DefaultFullImage { get; set; }
        [Required] public String DefaultChibiImage { get; set; }
    }
}