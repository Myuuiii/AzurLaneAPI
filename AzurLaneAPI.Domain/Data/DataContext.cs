using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Data;

public class DataContext : IdentityDbContext<ApiUser, ApiRole, Guid, IdentityUserClaim<Guid>, ApiUserRole,
	IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
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

	public DbSet<SignupCode> SignupCodes { get; set; }

	private static string ConnectionString => Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
	                                          "Host=localhost;Database=azurlaneapi;User=root";

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		builder.Entity<ApiUser>()
			.HasMany(ur => ur.UserRoles)
			.WithOne(u => u.User)
			.HasForeignKey((ur => ur.UserId))
			.IsRequired();
		
		builder.Entity<ApiRole>()
			.HasMany(ur => ur.UserRoles)
			.WithOne(u => u.Role)
			.HasForeignKey((ur => ur.RoleId))
			.IsRequired();
	}
}