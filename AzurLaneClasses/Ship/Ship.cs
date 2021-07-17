using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzurLaneClasses.Ship
{
    public class Ship
    {
        // * Identity Properties
        [Key] public Guid Id { get; set; }

        // * Properties
        [Required] public String ShipId { get; set; }
        [Required] public String Name { get; set; }
        [Required] public ShipRarity Rarity { get; set; }
        [Required] public ShipNation Nation { get; set; }
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

        // * Not Mapped Properties
        public List<ShipSkin> Skins { get; set; }

        // ? Ship Statistics
        [Required] public ShipStats BaseStatsId { get; set; }
        [Required] public ShipStats Level100StatsId { get; set; }
        public ShipStats Level100RetrofitStatsId { get; set; }
        [Required] public ShipStats Level120StatsId { get; set; }
        public ShipStats Level120RetrofitStatsId { get; set; }

        // ? Ship Equippables
        [Required] public ShipEquippable? EquippableTypeSlot1 { get; set; }
        [Required] public ShipEquippable? EquippableTypeSlot2 { get; set; }
        [Required] public ShipEquippable? EquippableTypeSlot3 { get; set; }

        // * External Object Ids
        [Required] public Guid ClassId { get; set; }
    }
}
