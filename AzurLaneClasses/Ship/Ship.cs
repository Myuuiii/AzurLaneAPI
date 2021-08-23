using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
	public class Ship
	{
		public Ship() { }

		// * Properties
		[JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
		[Key] public String ShipId { get; set; }

		public String Name { get; set; }
		public String Rarity { get; set; }
		public ShipStars Stars { get; set; }
		public String Nation { get; set; }
		public String Type { get; set; }

		// ? Images
		public String ThumbnailImage { get; set; }

		// ? Lists
		public List<ShipSkin> Skins { get; set; } = new List<ShipSkin>();
		public List<ShipSkill> Skills { get; set; } = new List<ShipSkill>();
		public List<ShipLimitBreaks> LimitBreaks { get; set; } = new List<ShipLimitBreaks>();
		public List<ShipGalleryItem> Gallery { get; set; } = new List<ShipGalleryItem>();
		public List<ShipEquippableSlot> EquippableSlots { get; set; } = new List<ShipEquippableSlot>();
		public List<ShipQuote> Quotes { get; set; } = new List<ShipQuote>();


		// ? Ship Statistics
		public ShipStats BaseStats { get; set; }
		public ShipStats Level100Stats { get; set; }
		public ShipStats Level100RetrofitStats { get; set; }
		public ShipStats Level120Stats { get; set; }
		public ShipStats Level120RetrofitStats { get; set; }


		// ? Enhancement, Scrap, Construction
		public ShipEnhanceValues EnhanceValue { get; set; } = null;
		public ShipScrapValues ScrapValue { get; set; } = null;
		public ShipConstruction Construction { get; set; } = null;


		// ? Misc Information
		public ShipArtist Artist { get; set; } = null;
		public ShipPixiv Pixiv { get; set; } = null;
		public ShipTwitter Twitter { get; set; } = null;
		public ShipWeb Web { get; set; } = null;
		public ShipVoiceActor VoiceActor { get; set; } = null;
	}
}
