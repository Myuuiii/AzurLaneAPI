using AzurLaneAPI.API;
using AzurLaneAPI.API.Services;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiApplicationService();
builder.Services.AddApiDataService();
builder.Services.AddIdentityService();

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

			RoleManager<APIRole> roleManager = scopeServiceProvider.GetRequiredService<RoleManager<APIRole>>();
			await Seeder.SeedAsync(context, roleManager);
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
app.UseAuthorization();

app.MapControllers();
app.Run("http://[::]:80");