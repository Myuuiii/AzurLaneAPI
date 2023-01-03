namespace AzurLaneAPI.API.Routes;

public static class V1
{
	public const string Base = "api/v1/";

	public static class Admin
	{
		public const string Controller = Base + "admin/";
		public const string GetUsersWithRoles = "users-with-roles";
		public const string UpdateRolesForUser = "update-roles-for-user/{username}";
	}

	public static class Auth
	{
		public const string Controller = Base + "auth/";
		public const string Login = "login";
		public const string Register = "register";
		public const string Refresh = "refresh";
	}

	public static class EnumInfo
	{
		public const string Controller = Base + "enum/";
		public const string Rarity = "rarity";
		public const string Armor = "armor";
	}

	public static class Ships
	{
		public const string Controller = Base + "ships/";
		public const string GetAll = "";
		public const string GetSingleById = "{id}";
		public const string GetSingleByName = "name/{name}";

		public const string Create = "";
		public const string Update = "{id}";
		public const string Delete = "{id}";

		public const string Minimal = "minimal";
		
		public const string Thumbnails = "images/thumbbails";
	}

	public static class Factions
	{
		public const string Controller = Base + "factions/";
		public const string GetAll = "";
		public const string GetSingleById = "{id}";
		public const string GetSingleByName = "name/{name}";

		public const string Create = "";
		public const string Update = "{id}";
		public const string Delete = "{id}";
	}

	public static class ShipTypes
	{
		public const string Controller = Base + "shiptypes/";
		public const string GetAll = "";
		public const string GetSingleById = "{id}";
		public const string GetSingleByName = "name/{name}";

		public const string Create = "";
		public const string Update = "{id}";
		public const string Delete = "{id}";
	}

	public static class ShipTypeSubclasses
	{
		public const string Controller = Base + "shiptypesubclasses/";
		public const string GetAll = "";
		public const string GetSingleById = "{id}";
		public const string GetSingleByName = "name/{name}";

		public const string Create = "";
		public const string Update = "{id}";
		public const string Delete = "{id}";
	}
}