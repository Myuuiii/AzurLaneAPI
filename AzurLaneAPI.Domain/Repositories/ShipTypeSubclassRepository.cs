using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class ShipTypeSubclassRepository : Repository<ShipTypeSubclass, Guid>, IShipTypeSubclassRepository
{
	public ShipTypeSubclassRepository(DataContext context) : base(context)
	{
	}

	public new async Task<IEnumerable<ShipTypeSubclass>> GetAsync()
	{
		return await Context.ShipTypeSubclasses.Include(x => x.ShipType).ToListAsync();
	}

	public new async Task<ShipTypeSubclass> GetAsync(Guid id)
	{
		return await Context.ShipTypeSubclasses.Include(x => x.ShipType).FirstAsync(x => x.Id == id);
	}

	public async Task<bool> ExistsForShipTypeAsync(Guid shipTypeId, Guid id)
	{
		ShipType type = Context.ShipTypes.First(x => x.Id == shipTypeId);
		return await Context.ShipTypeSubclasses.Include(x => x.ShipType)
			.AnyAsync(x => x.ShipType == type && x.Id == id);
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.ShipTypeSubclasses.AnyAsync(x => x.Name == name);
	}

	public async Task<ShipTypeSubclass> GetByNameAsync(string name)
	{
		return await Context.ShipTypeSubclasses.Include(x => x.ShipType).FirstAsync(x => x.Name == name);
	}
}