using System;
using System.Collections.Generic;
using System.IO;
using AzurLaneClasses.Equipment;
using AzurLaneClasses.Ship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using static AzurLaneClasses.Equipment.EquipmentOverrides;

namespace AzurLaneClasses
{
    public class AzurLaneDbContext : DbContext
    {
        private static String ConfigFileName = "./appConfiguration.json";
        public AzurLaneDbContext()
        {
            try
            {
                if (File.Exists(ConfigFileName))
                {
                    this.ConnString = JsonConvert.DeserializeObject<ApplicationConfiguration>(File.ReadAllText(ConfigFileName)).GetConnString();
                }
                else
                {
                    File.WriteAllText(ConfigFileName, JsonConvert.SerializeObject(new ApplicationConfiguration()));
                    throw new FileNotFoundException("A new configuration file has been created due to it not existing.");
                }
            }
            catch
            {
                throw new Exception("Something went wrong while instantiating a new Azur Lane Database Context");
            }
        }

        private String ConnString = "";

        // * Ships
        public DbSet<Ship.Ship> Ships { get; set; }
        public DbSet<Ship.ShipStats> ShipStats { get; set; }

        public DbSet<Ship.ShipSkin> ShipSkins { get; set; }

        // * Events
        public DbSet<ALEvent> Events { get; set; }

        // * Campaign
        public DbSet<CampaignLevel> CampaignLevels { get; set; }

        // * Construction pool
        public DbSet<ConstructionPool> ConstructionPools { get; set; }

        // * Equipment
        public DbSet<DestroyerGun> DestroyerGuns { get; set; }
        public DbSet<LightCruiserGun> LightCruiserGuns { get; set; }
        public DbSet<HeavyCruiserGun> HeavyCruiserGuns { get; set; }
        public DbSet<LargeCruiserGun> LargeCruiserGuns { get; set; }
        public DbSet<BattleshipGun> BattleshipGuns { get; set; }

        public DbSet<SubmarineTorpedo> SubmarineTorpedoes { get; set; }
        public DbSet<Torpedo> Torpedoes { get; set; }

        public DbSet<FighterPlane> FighterPlanes { get; set; }
        public DbSet<DiveBomberPlane> DiveBomberPlanes { get; set; }
        public DbSet<TorpedoBomberPlane> TorpedoBomberPlanes { get; set; }
        public DbSet<Seaplane> Seaplanes { get; set; }

        public DbSet<AntiAirGun> AntiAirGuns { get; set; }

        public DbSet<Auxiliary> Auxiliaries { get; set; }
        public DbSet<Cargo> Cargo { get; set; }


        // ! Authentication
        public DbSet<ALToken> ALTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!String.IsNullOrEmpty(ConnString))
            {
                optionsBuilder.UseMySql(ConnString, ServerVersion.AutoDetect(ConnString));
            }
            else
            {
                throw new Exception("The Database Connection String has not been configured correctly");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var splitStringConverter = new ValueConverter<IEnumerable<String>, String>(v => String.Join(";", v), v => v.Split(new[] { ';' }));
            modelBuilder.Entity<ShipLimitBreak>().Property(nameof(ShipLimitBreak.First)).HasConversion(splitStringConverter);
            modelBuilder.Entity<ShipLimitBreak>().Property(nameof(ShipLimitBreak.Second)).HasConversion(splitStringConverter);
            modelBuilder.Entity<ShipLimitBreak>().Property(nameof(ShipLimitBreak.Third)).HasConversion(splitStringConverter);
        }
    }
}