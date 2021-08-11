using System;

namespace AzurLaneAPI.Routes.V1
{
    public static partial class Routes
    {
        public static class Scrapers 
		{
			public static class Ships 
			{
				public const String GetPageUrls = "/scrapers/ships/urls";
				public const String GetShips = "/scrapers/ships";
			}

			public static class Barrages 
			{
				public const String GetBarrages = "/scrapers/barrages";
			}

			public static class Campaigns
			{
				public const String GetCampaigns = "/scrapers/campaigns";
			}
		}
    }
}