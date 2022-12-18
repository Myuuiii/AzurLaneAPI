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
		return await Context.SignupCodes.AnyAsync(x => !x.Used &&
			x.Code == code &&
			x.Expiration > DateTime.UtcNow);
	}

	public async Task<bool> UseCodeAsync(string code, string userName)
	{
		SignupCode signupCode = await Context.SignupCodes.FirstAsync(x => x.Code == code);
		signupCode.Used = true;
		signupCode.UsedBy = userName;
		signupCode.UsedAt = DateTime.UtcNow;
		return await Context.SaveChangesAsync() > 0;
	}
}