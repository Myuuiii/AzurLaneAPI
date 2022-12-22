namespace AzurLaneAPI.API.Services;

public static class ApiApplicationService
{
	public static IServiceCollection AddApiApplicationService(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
		services.AddCors();
		return services;
	}
}