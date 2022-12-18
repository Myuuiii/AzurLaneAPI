namespace AzurLaneAPI.API;

public static class IdentityNames
{
	public static class Roles
	{
		public const string Admin = "Admin";
		public const string Moderator = "Moderator";
		public const string Contributor = "Contributor";
		public const string Member = "Member";
	}

	public static class Policies
	{
		public const string RequireAdminRole = "RequireAdminRole";
		public const string RequireModeratorRole = "RequireModeratorRole";
		public const string RequireContributorRole = "RequireContributorRole";
		public const string RequireMemberRole = "RequireMemberRole";
	}
}