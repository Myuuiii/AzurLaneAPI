namespace AzurLaneAPI.API.Routes;

public static class V1
{
	public const string Base = "api/v1";

	public static class EnumInfo
	{
		public const string Base = "/enum";
		public const string Rarity = Base + "/rarity";
		public const string Armor = Base + "/armor";
	}

	public static class Ships
	{
		public const string Base = "/ships";
		public const string GetAll = Base;
		public const string GetSingleById = Base + "/{id}";
		public const string GetSingleByName = Base + "/name/{name}";

		public const string Create = Base;
		public const string Update = Base + "/{id}";
		public const string Delete = Base + "/{id}";
	}

	public static class Factions
	{
		public const string Base = "/factions";
		public const string GetAll = Base;
		public const string GetSingleById = Base + "/{id}";
		public const string GetSingleByName = Base + "/name/{name}";

		public const string Create = Base;
		public const string Update = Base + "/{id}";
		public const string Delete = Base + "/{id}";
	}

	public static class ShipTypes
	{
		public const string Base = "/shiptypes";
		public const string GetAll = Base;
		public const string GetSingleById = Base + "/{id}";
		public const string GetSingleByName = Base + "/name/{name}";

		public const string Create = Base;
		public const string Update = Base + "/{id}";
		public const string Delete = Base + "/{id}";
	}

	public static class ShipTypeSubclasses
	{
		public const string Base = "/shiptypesubclasses";
		public const string GetAll = Base;
		public const string GetSingleById = Base + "/{id}";
		public const string GetSingleByName = Base + "/name/{name}";

		public const string Create = Base;
		public const string Update = Base + "/{id}";
		public const string Delete = Base + "/{id}";
	}
}