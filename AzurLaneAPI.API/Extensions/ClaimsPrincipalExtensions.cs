using System.Security.Claims;

namespace AzurLaneAPI.API.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static string GetUsername(this ClaimsPrincipal user) =>
		user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
}