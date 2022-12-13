namespace AzurLaneAPI.API;

public static class IdentityNames
{
	public static class Roles
	{
		public const string ADMIN = "Admin";
		public const string MODERATOR = "Moderator";
		public const string CONTRIBUTOR = "Contributor";
		public const string MEMBER = "Member";
	}

	public static class Policies
	{
		public const string RequireAdminRole = "RequireAdminRole";
		public const string RequireModeratorRole = "RequireModeratorRole";
		public const string RequireContributorRole = "RequireContributorRole";
		public const string RequireMemberRole = "RequireMemberRole";
	}
}