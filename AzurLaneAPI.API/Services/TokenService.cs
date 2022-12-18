using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AzurLaneAPI.API.Services;

public interface ITokenService
{
	Task<string> GenerateTokenAsync(ApiUser user);
}

public sealed class TokenService : ITokenService
{
	private readonly SymmetricSecurityKey _signingKey;
	private readonly string _signingKeyToken = EnvReader.GetSigningKey();
	private readonly UserManager<ApiUser> _userManger;

	public TokenService(UserManager<ApiUser> userManger)
	{
		_userManger = userManger;
		_signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_signingKeyToken));
	}

	public async Task<string> GenerateTokenAsync(ApiUser user)
	{
		List<Claim> claims = new()
		{
			new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
		};

		// Add roles to claim
		IList<string> roles = await _userManger.GetRolesAsync(user);
		claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

		SigningCredentials creds = new(_signingKey, SecurityAlgorithms.HmacSha256Signature);
		SecurityTokenDescriptor tokenDescriptor = new()
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(7),
			SigningCredentials = creds
		};

		JwtSecurityTokenHandler tokenHandler = new();
		SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}