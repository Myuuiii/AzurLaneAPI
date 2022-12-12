using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class FactionRepository : Repository<Faction, Guid>, IFactionRepository
{
	public FactionRepository(DataContext context) : base(context)
	{
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.Factions.AnyAsync(x => x.Name == name);
	}

	public async Task<Faction> GetByNameAsync(string name)
	{
		return await Context.Factions.FirstAsync(x => x.Name == name);
	}
}