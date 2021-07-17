using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        
        public DbSet<Ship.ShipClass> ShipClasses { get; set; }
        public DbSet<Ship.ShipSkin> ShipSkins { get; set; }

        // * Events
        public DbSet<ALEvent> Events { get; set; }

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
    }
}