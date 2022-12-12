using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class ShipTypeRepository : Repository<ShipType, Guid>, IShipTypeRepository
{
	public ShipTypeRepository(DataContext context) : base(context)
	{
	}

	public new async Task<IEnumerable<ShipType>> GetAsync()
	{
		return await Context.ShipTypes.Include(x => x.Subclasses).ToListAsync();
	}

	public new async Task<ShipType> GetAsync(Guid id)
	{
		return await Context.ShipTypes.Include(x => x.Subclasses).FirstAsync(x => x.Id == id);
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.ShipTypes.AnyAsync(x => x.Name == name);
	}

	public async Task<ShipType> GetByNameAsync(string name)
	{
		return await Context.ShipTypes.Include(x => x.Subclasses).FirstAsync(x => x.Name == name);
	}
}