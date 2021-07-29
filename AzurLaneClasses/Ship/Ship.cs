using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AzurLaneClasses.Import;

namespace AzurLaneClasses.Ship
{
    public class Ship
    {
        public Ship() { }

        public Ship(ShipDataImportModel importModel)
        {
            this.Name = importModel.names.en;
            this.ShipId = importModel.id;
            this.Rarity = importModel.rarity;
            this.Stars = new ShipStars { Stars = importModel.stars.stars, Count = importModel.stars.value };
            this.Nation = importModel.nationality;
            this.Type = importModel.hullType;
            this.ThumbnailImage = importModel.thumbnail;

            // Default skin import
            var defSkin = importModel.skins.First(s => s.name == "Default");
            this.DefaultSkin = new ShipSkin
            {
                Name = defSkin.name,
                ImageUrl = defSkin.image,
                BackgroundUrl = defSkin.background,
                ChibiUrl = defSkin.chibi,
                Live2dModel = defSkin.info.live2dModel,
                ObtainedFrom = defSkin.info.obtainedFrom
            };

            if (importModel.skins != null)
            {
                foreach (var skin in importModel.skins)
                {
                    this.Skins.Add(new ShipSkin
                    {
                        Name = skin.name,
                        ImageUrl = skin.image,
                        BackgroundUrl = skin.background,
                        ChibiUrl = skin.chibi,
                        Live2dModel = skin.info.live2dModel,
                        ObtainedFrom = skin.info.obtainedFrom
                    });
                }
            }

            if (importModel.skills != null)
            {
                foreach (var skill in importModel.skills)
                {
                    this.Skills.Add(new ShipSkill
                    {
                        IconUrl = skill.icon,
                        Name = skill.names.en,
                        Description = skill.description,
                        Color = skill.color
                    });
                }
            }


            if (importModel.limitBreaks != null)
            {
                foreach (var limitBreak in importModel.limitBreaks)
                {
                    this.LimitBreaks.Add(new ShipLimitBreaks
                    {
                        LimitBreaks = limitBreak
                    });
                }
            }


            if (importModel.gallery != null)
            {
                foreach (var pic in importModel.gallery)
                {
                    this.Gallery.Add(new ShipGalleryItem
                    {
                        Description = pic.description,
                        Url = pic.url
                    });
                }
            }

            this.BaseStats = new ShipStats(importModel.stats.baseStats);
            this.Level100Stats = new ShipStats(importModel.stats.level100);
            this.Level120Stats = new ShipStats(importModel.stats.level120);
            if (importModel.stats.level100Retrofit != null) this.Level100RetrofitStats = new ShipStats(importModel.stats.level100Retrofit);
            if (importModel.stats.level120Retrofit != null) this.Level100RetrofitStats = new ShipStats(importModel.stats.level120Retrofit);

            if (importModel.slots != null)
            {
                foreach (var slot in importModel.slots)
                {
                    this.EquippableSlots.Add(new ShipEquippableSlot
                    {
                        MaxEfficiency = slot.maxEfficiency,
                        MinEfficiency = slot.minEfficiency,
                        Type = slot.type,
                        Max = slot.max
                    });
                }
            }

            if (importModel.enhanceValue != null)
            {
                this.EnhanceValue = new ShipEnhanceValues
                {
                    Firepower = importModel.enhanceValue.firepower,
                    Torpedo = importModel.enhanceValue.torpedo,
                    Aviation = importModel.enhanceValue.aviation,
                    Reload = importModel.enhanceValue.reload
                };
            }

            if (importModel.scrapValue != null)
            {
                this.ScrapValue = new ShipScrapValues
                {
                    Coins = importModel.scrapValue.coin,
                    Oil = importModel.scrapValue.oil,
                    Medals = importModel.scrapValue.medal
                };
            }

            if (importModel.construction != null)
            {
                this.Construction = new ShipConstruction
                {
                    ConstructionTime = importModel.construction.constructionTime,
                    Availability = new ConstructionAvailability()
                };

                this.Construction.Availability.Light = Convert.ToString(importModel.construction.availableIn.light);
                this.Construction.Availability.Heavy = Convert.ToString(importModel.construction.availableIn.heavy);
                this.Construction.Availability.Special = Convert.ToString(importModel.construction.availableIn.aviation);
                this.Construction.Availability.Limited = Convert.ToString(importModel.construction.availableIn.limited);
                this.Construction.Availability.Exchange = Convert.ToString(importModel.construction.availableIn.exchange);
            }

            if (importModel.misc != null)
            {
                this.Misc = new ShipMisc();

                if (importModel.misc.artist != null)
                {
                    this.Misc.Artist.Name = importModel.misc.artist.name;
                    this.Misc.Artist.Url = importModel.misc.artist.url;
                }
                if (importModel.misc.pixiv != null)
                {
                    this.Misc.Pixiv.Name = importModel.misc.pixiv.name;
                    this.Misc.Pixiv.Url = importModel.misc.pixiv.url;
                }
                if (importModel.misc.twitter != null)
                {
                    this.Misc.Twitter.Name = importModel.misc.twitter.name;
                    this.Misc.Twitter.Url = importModel.misc.twitter.url;
                }
                if (importModel.misc.web != null)
                {
                    this.Misc.Web.Name = importModel.misc.web.name;
                    this.Misc.Web.Url = importModel.misc.web.url;
                }
                if (importModel.misc.voice != null)
                {
                    this.Misc.VoiceActor.Name = importModel.misc.voice.name;
                    this.Misc.VoiceActor.Url = importModel.misc.voice.url;
                }
            }
        }

        // * Properties
        public Guid Id { get; set; } = Guid.NewGuid();
        [Key] public String ShipId { get; set; }

        public String Name { get; set; }
        public String Rarity { get; set; }
        public ShipStars Stars { get; set; }
        public String Nation { get; set; }
        public String Type { get; set; }

        // ? Images
        public String ThumbnailImage { get; set; }
        public ShipSkin DefaultSkin { get; set; } = null;

        // ? Lists
        public List<ShipSkin> Skins { get; set; } = new List<ShipSkin>();
        public List<ShipSkill> Skills { get; set; } = new List<ShipSkill>();
        public List<ShipLimitBreaks> LimitBreaks { get; set; } = new List<ShipLimitBreaks>();
        public List<ShipGalleryItem> Gallery { get; set; } = new List<ShipGalleryItem>();
        public List<ShipEquippableSlot> EquippableSlots { get; set; } = new List<ShipEquippableSlot>();


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
        public ShipMisc Misc { get; set; } = null;
    }
}
