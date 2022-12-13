using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.API.Services;

public static class ApiDataService
{
	public static IServiceCollection AddApiDataService(this IServiceCollection services)
	{
		services.AddScoped<IShipRepository, ShipRepository>();
		services.AddScoped<IShipTypeSubclassRepository, ShipTypeSubclassRepository>();
		services.AddScoped<IShipTypeRepository, ShipTypeRepository>();
		services.AddScoped<IFactionRepository, FactionRepository>();
		services.AddScoped<ISignupCodeRepository, SignupCodeRepository>();
		services.AddScoped<IUserRepository, UserRepository>();

		services.AddDbContext<DataContext>(options =>
			options.UseMySql(EnvReader.GetConnString(), ServerVersion.AutoDetect(EnvReader.GetConnString())));

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		return services;
	}
}