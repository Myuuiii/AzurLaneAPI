using System;

namespace AzurLaneAPI.Routes.V1
{
	public static partial class Routes
	{
		public const String Base = "/v1";

		public static class Ships
		{
			public const String GetAll = "/ships";
			public const String GetAllMinimal = "/ships/minimal";
			public const String GetId = "/ships/{id}";
			public const String GetMinimalId = "/ships/{id}/minimal";
			public const String GetName = "/ships/name/{name}";
			public const String GetMinimalName = "/ships/name/{name}/minimal";
			public const String Import = "/ships/";

			public static class ShipGallery
			{
				public const String GetAll = "/shipgallery";
				public const String GetAllByShipId = "/shipgallery/{id}";
				public const String GetAllByShipName = "/shipgallery/name/{name}";
			}

			public static class ShipSkins
			{
				public const String GetAll = "/shipskins";
				public const String GetAllByShipId = "/shipskins/{id}";
				public const String GetAllByShipName = "/shipskins/name/{name}";
			}

			public static class ShipStats
			{
				public const String Base = "/shipstats/base/{id}";
				public const String BaseName = "/shipstats/base/name/{name}";

				public const String Lvl100 = "/shipstats/100/{id}";
				public const String Lvl100Name = "/shipstats/100/{name}";

				public const String Lvl100Retro = "/shipstats/100R/{id}";
				public const String Lvl100RetroName = "/shipstats/100R/name/{name}";

				public const String Lvl120 = "/shipstats/120/{id}";
				public const String Lvl120Name = "/shipstats/120/name/{name}";

				public const String Lvl120Retro = "/shipstats/120R/{id}";
				public const String Lvl120RetroName = "/shipstats/120R/name/{name}";
			}
		}

		public static class Barrages
		{
			public const String GetAll = "/barrages";
			public const String GetId = "/barrages/{id}";
			public const String GetAllByName = "/barrages/ship/{name}";
			public const String Import = "/barrages";
		}

		public static class Events
		{
			public const String GetAll = "/events";
			public const String GetId = "/events/{id}";
			public const String Create = "/events";
			public const String Update = "/events/{eventId}";
			public const String Delete = "/events/{eventId}";
		}

		public static class Campaign
		{
			public const String GetAll = "/campaign";
			public const String GetId = "/campaign/{id}";
			public const String GetSelect = "/campaign/{chapter}/{level}";
		}

		public static class Construction
		{
			public const String GetPools = "/construction";
			public const String GetPool = "/construction/{id}";
		}

		
	}
}