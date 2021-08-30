using System;

namespace AzurLaneAPI.Routes.V1
{
	public static partial class Routes
	{
		public static class Campaign
		{
			public const String GetAll = "/campaign";
			public const String GetId = "/campaign/{id}";
			public const String GetSelect = "/campaign/{chapter}/{level}";
			public const String ImportScraper = "campaign/scrape";
		}
	}
}