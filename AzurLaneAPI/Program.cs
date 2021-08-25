using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzurLaneAPI
{
    public class Program
    {   
        /// <summary>
        /// Static General API configuration
        /// </summary>
        public static ApplicationConfiguration _config;
        
        /// <summary>
        /// Main entry point for the API
        /// </summary>
        public static void Main(string[] args)
        {
            _config = ConfigLoader.GetConfiguration();
            Seeders.CampaignSeeder.Seed();
            Seeders.ConstructionPoolSeeder.Seed();
            
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://0.0.0.0:5020");
                });
    }
}
