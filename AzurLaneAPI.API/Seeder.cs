using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.API;

public static class Seeder
{
	public static async Task SeedAsync(DataContext context, RoleManager<APIRole> roleManager)
	{
		if (await context.Roles.AnyAsync())
			return; // Database has data

		List<APIRole> roles = new()
		{
			new APIRole { Name = IdentityNames.Roles.MEMBER },
			new APIRole { Name = IdentityNames.Roles.CONTRIBUTOR },
			new APIRole { Name = IdentityNames.Roles.MODERATOR },
			new APIRole { Name = IdentityNames.Roles.ADMIN }
		};

		foreach (APIRole role in roles)
			await roleManager.CreateAsync(role);
	}
}