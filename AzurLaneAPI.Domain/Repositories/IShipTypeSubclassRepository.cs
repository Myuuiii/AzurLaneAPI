using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Repositories;

public interface IShipTypeSubclassRepository : IRepository<ShipTypeSubclass, Guid>
{
	public Task<bool> ExistsForShipTypeAsync(Guid shipTypeId, Guid id);

	public Task<bool> ExistsWithNameAsync(string name);
	public Task<ShipTypeSubclass> GetByNameAsync(string name);
}