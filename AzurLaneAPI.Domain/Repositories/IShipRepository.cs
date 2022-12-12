using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Repositories;

public interface IShipRepository : IRepository<Ship, string>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<Ship> GetByNameAsync(string name);
}