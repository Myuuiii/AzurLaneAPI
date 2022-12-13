using AutoMapper;
using AzurLaneAPI.API.Routes;
using AzurLaneAPI.API.Services;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.Auth;
using AzurLaneAPI.Domain.Dtos.Identity;
using AzurLaneAPI.Domain.Identity;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers;

[AllowAnonymous]
[Route(Auth.Base)]
public class AuthController : ApiControllerBase
{
	private readonly ISignupCodeRepository _signupCodeRepository;
	private readonly ITokenService _tokenService;
	private readonly UserManager<APIUser> _userManager;
	private readonly IUserRepository _userRepository;

	public AuthController(DataContext ctx, IMapper mapper, ISignupCodeRepository signupCodeRepository,
		UserManager<APIUser> userManager, IUserRepository userRepository, ITokenService tokenService) : base(ctx,
		mapper)
	{
		_tokenService = tokenService;
		_userRepository = userRepository;
		_userManager = userManager;
		_signupCodeRepository = signupCodeRepository;
	}

	[HttpPost(Auth.Login)]
	public async Task<ActionResult<APIUserDto>> Login([FromBody] LoginDto login)
	{
		if (!await _userRepository.ExistsWithNameAsync(login.UserName)) return NotFound();

		APIUser user = await _userRepository.GetByUsernameAsync(login.UserName);
		bool result = await _userManager.CheckPasswordAsync(user, login.Password);

		if (!result) return Unauthorized("Invalid password");
		return new APIUserDto
		{
			Token = await _tokenService.GenerateTokenAsync(user),
			UserName = user.UserName
		};
	}

	[HttpPost(Auth.Register)]
	public async Task<ActionResult<APIUserDto>> Register([FromBody] RegisterDto register)
	{
		if (!await _signupCodeRepository.IsValidAsync(register.SignupCode))
			return BadRequest("Invalid signup code, it might be expired or already used");

		if (await _userRepository.ExistsWithNameAsync(register.UserName))
			return BadRequest("Username is taken");

		APIUser? user = Mapper.Map<APIUser>(register);
		user.UserName = register.UserName.ToLower();

		IdentityResult result = await _userManager.CreateAsync(user, register.Password);
		if (!result.Succeeded) return BadRequest(result.Errors);

		IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "Member");
		if (!roleResult.Succeeded) return BadRequest(result.Errors);

		return new APIUserDto
		{
			Token = await _tokenService.GenerateTokenAsync(user),
			UserName = user.UserName
		};
	}
}