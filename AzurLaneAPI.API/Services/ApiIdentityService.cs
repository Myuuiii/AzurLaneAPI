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
		services.AddIdentityCore<APIUser>(options =>
			{
				options.Password.RequireNonAlphanumeric = false;
				options.User.RequireUniqueEmail = true;
			})
			.AddRoles<APIRole>()
			.AddRoleManager<RoleManager<APIRole>>()
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
				policy => { policy.RequireRole(IdentityNames.Roles.ADMIN); });
			options.AddPolicy(IdentityNames.Policies.RequireModeratorRole,
				policy => { policy.RequireRole(IdentityNames.Roles.MODERATOR); });
			options.AddPolicy(IdentityNames.Policies.RequireContributorRole,
				policy => { policy.RequireRole(IdentityNames.Roles.CONTRIBUTOR); });
			options.AddPolicy(IdentityNames.Policies.RequireMemberRole,
				policy => { policy.RequireRole(IdentityNames.Roles.MEMBER); });
		});

		services.AddScoped<ITokenService, TokenService>();

		return services;
	}
}