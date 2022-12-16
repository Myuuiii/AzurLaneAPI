using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class ShipRepository : Repository<Ship, string>, IShipRepository
{
	public ShipRepository(DataContext context) : base(context)
	{
	}

	public new async Task<IEnumerable<Ship>> GetAsync()
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.ToListAsync();
	}

	public new async Task<Ship> GetAsync(string id)
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.FirstAsync(x => x.Id == id);
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.Ships
			.AnyAsync(x => x.EnglishName == name || x.JapaneseName == name || x.ChineseName == name);
	}

	public async Task<Ship> GetByNameAsync(string name)
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.FirstAsync(x => x.EnglishName == name || x.JapaneseName == name || x.ChineseName == name);
	}
}