using System;

namespace AzurLaneAPI.Routes.V1
{
    public static partial class Routes
    {
        public static class Barrages
		{
			public const String GetAll = "/barrages";
			public const String GetId = "/barrages/{id}";
			public const String GetAllByName = "/barrages/ship/{name}";
			public const String ImportScraper = "/barrages/scrape";
		}
    }
}