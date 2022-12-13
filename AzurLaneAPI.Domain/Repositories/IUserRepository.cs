using AzurLaneAPI.Domain.Identity;

namespace AzurLaneAPI.Domain.Repositories;

public interface IUserRepository : IRepository<APIUser, Guid>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<APIUser> GetByUsernameAsync(string username);
}