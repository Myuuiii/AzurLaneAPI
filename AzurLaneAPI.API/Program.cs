using AzurLaneAPI.API;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
	options.UseMySql(EnvReader.GetConnString(), ServerVersion.AutoDetect(EnvReader.GetConnString())));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
	.AddScoped<IShipRepository, ShipRepository>()
	.AddScoped<IShipTypeSubclassRepository, ShipTypeSubclassRepository>()
	.AddScoped<IShipTypeRepository, ShipTypeRepository>()
	.AddScoped<IFactionRepository, FactionRepository>();

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
		catch (Exception ex)
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

app.UseAuthorization();

app.MapControllers();

app.Run("http://[::]:80");