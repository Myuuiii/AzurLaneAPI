using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Repositories;

public interface IFactionRepository : IRepository<Faction, Guid>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<Faction> GetByNameAsync(string name);
}