using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Data;

public class DataContext : DbContext
{
	public DataContext()
	{
	}

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<Ship> Ships { get; set; }

	public DbSet<ShipType> ShipTypes { get; set; }
	public DbSet<ShipTypeSubclass> ShipTypeSubclasses { get; set; }
	public DbSet<ShipStats> ShipStats { get; set; }

	public DbSet<Faction> Factions { get; set; }

	private static string ConnectionString => Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
	                                          "Host=localhost;Database=azurlaneapi;User=root";

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
	}
}