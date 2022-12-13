using AzurLaneAPI.API.Services;
using AzurLaneAPI.Domain.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddIdentityService()
	.AddApiDataService();

WebApplication app = builder.Build();

await using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
{
	using (IServiceScope serviceScope = serviceProvider.CreateScope())
	{
		IServiceProvider scopeServiceProvider = serviceScope.ServiceProvider;
		try
		{
			DataContext context = scopeServiceProvider.GetRequiredService<DataContext>();
			context.Database.Migrate();
		}
		catch (Exception)
		{
			Console.WriteLine("An error occurred while migrating the database");
		}
	}
}


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.MapControllers();
app.Run("http://[::]:80");