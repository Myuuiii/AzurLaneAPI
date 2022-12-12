using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Repositories;

public interface IShipTypeRepository : IRepository<ShipType, Guid>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<ShipType> GetByNameAsync(string name);
}