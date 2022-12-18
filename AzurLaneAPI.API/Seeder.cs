using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.Auth;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.API;

public static class Seeder
{
	public static async Task SeedAsync(DataContext context, RoleManager<ApiRole> roleManager,
		UserManager<ApiUser> userManager, IMapper mapper)
	{
		if (!await context.Roles.AnyAsync())
		{
			List<ApiRole> roles = new()
			{
				new ApiRole { Name = IdentityNames.Roles.Member },
				new ApiRole { Name = IdentityNames.Roles.Contributor },
				new ApiRole { Name = IdentityNames.Roles.Moderator },
				new ApiRole { Name = IdentityNames.Roles.Admin }
			};

			foreach (ApiRole role in roles)
				await roleManager.CreateAsync(role);
		}

		if (!await context.Users.AnyAsync(x => x.UserName == "admin"))
		{
			RegisterDto registerDto = new()
			{
				UserName = "admin",
				Email = "admin@admin.com",
				Password = EnvReader.GetAdminPassword(),
				SignupCode = "admin"
			};

			ApiUser? user = mapper.Map<ApiUser>(registerDto);
			user.UserName = registerDto.UserName.ToLower();
			await userManager.CreateAsync(user, registerDto.Password);
			await userManager.AddToRolesAsync(user, new[] { IdentityNames.Roles.Admin, IdentityNames.Roles.Contributor, IdentityNames.Roles.Moderator, IdentityNames.Roles.Member });
		}
	}
}
