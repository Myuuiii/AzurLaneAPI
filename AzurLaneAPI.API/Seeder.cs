using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.API;

public static class Seeder
{
	public static async Task SeedAsync(DataContext context, RoleManager<ApiRole> roleManager)
	{
		if (await context.Roles.AnyAsync())
			return; // Database has data

		List<ApiRole> roles = new()
		{
			new ApiRole { Name = IdentityNames.Roles.MEMBER },
			new ApiRole { Name = IdentityNames.Roles.CONTRIBUTOR },
			new ApiRole { Name = IdentityNames.Roles.MODERATOR },
			new ApiRole { Name = IdentityNames.Roles.ADMIN }
		};

		foreach (ApiRole role in roles)
			await roleManager.CreateAsync(role);
	}
}