using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class SignupCodeRepository : Repository<SignupCode, int>, ISignupCodeRepository
{
	public SignupCodeRepository(DataContext context) : base(context)
	{
	}


	public async Task<bool> IsValidAsync(string code)
	{
		return await Context.SignupCodes.AnyAsync(x =>
			x.Used == false &&
			x.Code == code &&
			x.Expiration < DateTime.UtcNow);
	}
}