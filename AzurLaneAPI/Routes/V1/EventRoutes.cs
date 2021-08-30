using System;

namespace AzurLaneAPI.Routes.V1
{
    public static partial class Routes
    {
        public static class Events
		{
			public const String GetAll = "/events";
			public const String GetId = "/events/{id}";
			public const String ImportScraper = "/events/scrape";
		}
    }
}