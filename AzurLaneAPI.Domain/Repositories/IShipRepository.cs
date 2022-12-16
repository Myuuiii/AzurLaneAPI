using AzurLaneAPI.Domain.APIQueryParameters;
using AzurLaneAPI.Domain.Dtos.Ship;
using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Repositories;

public interface IShipRepository : IRepository<Ship, string>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<Ship> GetByNameAsync(string name);
	public Task<IEnumerable<MinimalShipDataDto>> GetMinimalAsync(PaginationParameters parameters);
	public Task<IEnumerable<Ship>> GetAsync(PaginationParameters parameters);
}