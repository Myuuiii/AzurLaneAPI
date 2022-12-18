using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class UserRepository : Repository<ApiUser, Guid>, IUserRepository
{
	public UserRepository(DataContext context) : base(context)
	{
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.Users.AnyAsync(x => x.UserName == name);
	}

	public async Task<ApiUser> GetByUsernameAsync(string username)
	{
		return await Context.Users.FirstAsync(x => x.UserName == username);
	}
}