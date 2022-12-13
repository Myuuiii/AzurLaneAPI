using AzurLaneAPI.Domain.Identity;

namespace AzurLaneAPI.Domain.Repositories;

public interface ISignupCodeRepository : IRepository<SignupCode, int>
{
	public Task<bool> IsValidAsync(string code);
}