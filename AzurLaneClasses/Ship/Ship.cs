using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzurLaneClasses.Ship
{
    public class Ship
    {
        public Ship() { }

        // * Properties
        public Guid Id { get; set; } = Guid.NewGuid();
        [Key] public String ShipId { get; set; }

        public String Name { get; set; }
        public ShipRarity Rarity { get; set; }
        public ShipStars Stars { get; set; }
        public Nation Nation { get; set; }
        public ShipType Type { get; set; }

        // ? Images
        public String IconImage { get; set; }
        public String ThumbnailImage { get; set; }
        public ShipSkin DefaultSkin { get; set; } = null;

        // ? Lists
        public List<ShipSkin> Skins { get; set; } = new List<ShipSkin>();
        public List<ShipSkill> Skills { get; set; } = new List<ShipSkill>();
        public List<ShipLimitBreak> LimitBreaks { get; set; } = new List<ShipLimitBreak>();
        public List<ShipGalleryItem> Gallery { get; set; } = new List<ShipGalleryItem>();


        // ? Ship Statistics
        public ShipStats BaseStats { get; set; }
        public ShipStats Level100Stats { get; set; }
        public ShipStats Level100RetrofitStats { get; set; }
        public ShipStats Level120Stats { get; set; }
        public ShipStats Level120RetrofitStats { get; set; }

        // ? Ship Equippables
        public ShipEquippableSlot EquipSlot1 { get; set; } = null;
        public ShipEquippableSlot EquipSlot2 { get; set; } = null;
        public ShipEquippableSlot EquipSlot3 { get; set; } = null;


        // ? Enhancement, Scrap, Construction
        public ShipEnhanceValues EnhanceValue { get; set; } = null;
        public ShipScrapValues ScrapValue { get; set; } = null;
        public ShipConstruction Construction { get; set; } = null;


        // ? Misc Information
        public ShipMisc Misc { get; set; } = null;
    }
}
