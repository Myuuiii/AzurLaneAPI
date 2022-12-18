using System.Text;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AzurLaneAPI.API.Services;

public static class ApiIdentityService
{
	public static IServiceCollection AddIdentityService(this IServiceCollection services)
	{
		services.AddIdentityCore<ApiUser>(options =>
			{
				options.Password.RequireNonAlphanumeric = false;
				options.User.RequireUniqueEmail = true;
			})
			.AddRoles<ApiRole>()
			.AddRoleManager<RoleManager<ApiRole>>()
			.AddEntityFrameworkStores<DataContext>();

		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey =
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvReader.GetSigningKey())),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		});

		services.AddAuthorization(options =>
		{
			options.AddPolicy(IdentityNames.Policies.RequireAdminRole,
				policy => { policy.RequireRole(IdentityNames.Roles.Admin); });
			options.AddPolicy(IdentityNames.Policies.RequireModeratorRole,
				policy => { policy.RequireRole(IdentityNames.Roles.Moderator); });
			options.AddPolicy(IdentityNames.Policies.RequireContributorRole,
				policy => { policy.RequireRole(IdentityNames.Roles.Contributor); });
			options.AddPolicy(IdentityNames.Policies.RequireMemberRole,
				policy => { policy.RequireRole(IdentityNames.Roles.Member); });
		});

		services.AddScoped<ITokenService, TokenService>();

		return services;
	}
}