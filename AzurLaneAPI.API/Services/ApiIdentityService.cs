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

		// Policy based authorization
		services.AddAuthorization(options =>
		{
			options.AddPolicy("RequireAdminRole", policy => { policy.RequireRole("Admin"); });
		});

		services.AddScoped<ITokenService, TokenService>();

		return services;
	}
}