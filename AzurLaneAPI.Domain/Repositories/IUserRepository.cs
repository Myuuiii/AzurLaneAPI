using AzurLaneAPI.Domain.Identity;

namespace AzurLaneAPI.Domain.Repositories;

public interface IUserRepository : IRepository<ApiUser, Guid>
{
	public Task<bool> ExistsWithNameAsync(string name);
	public Task<ApiUser> GetByUsernameAsync(string username);
}