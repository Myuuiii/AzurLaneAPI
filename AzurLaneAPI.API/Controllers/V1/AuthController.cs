using AutoMapper;
using AzurLaneAPI.API.Controllers.V1;
using AzurLaneAPI.API.Extensions;
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

[Route(Routes.V1.Auth.Controller)]
public class AuthController : V1BaseController
{
	private readonly ISignupCodeRepository _signupCodeRepository;
	private readonly ITokenService _tokenService;
	private readonly UserManager<ApiUser> _userManager;
	private readonly IUserRepository _userRepository;

	public AuthController(DataContext ctx, IMapper mapper, ISignupCodeRepository signupCodeRepository,
		UserManager<ApiUser> userManager, IUserRepository userRepository, ITokenService tokenService) : base(ctx,
		mapper)
	{
		_tokenService = tokenService;
		_userRepository = userRepository;
		_userManager = userManager;
		_signupCodeRepository = signupCodeRepository;
	}

	[AllowAnonymous]
	[HttpPost(Routes.V1.Auth.Login)]
	public async Task<ActionResult<ApiUserDto>> Login([FromBody] LoginDto login)
	{
		if (!await _userRepository.ExistsWithNameAsync(login.UserName)) return NotFound();

		ApiUser user = await _userRepository.GetByUsernameAsync(login.UserName);
		bool result = await _userManager.CheckPasswordAsync(user, login.Password);

		if (!result) return Unauthorized("Invalid password");
		return new ApiUserDto
		{
			Token = await _tokenService.GenerateTokenAsync(user),
			UserName = user.UserName
		};
	}

	[AllowAnonymous]
	[HttpPost(Routes.V1.Auth.Register)]
	public async Task<ActionResult<ApiUserDto>> Register([FromBody] RegisterDto register)
	{
		if (!await _signupCodeRepository.IsValidAsync(register.SignupCode))
			return BadRequest("Invalid signup code, it might be expired or already used");

		if (await _userRepository.ExistsWithNameAsync(register.UserName))
			return BadRequest("Username is taken");

		ApiUser? user = Mapper.Map<ApiUser>(register);
		user.UserName = register.UserName.ToLower();

		IdentityResult result = await _userManager.CreateAsync(user, register.Password);
		if (!result.Succeeded) return BadRequest(result.Errors);

		IdentityResult roleResult = await _userManager.AddToRoleAsync(user, IdentityNames.Roles.MEMBER);
		if (!roleResult.Succeeded) return BadRequest(result.Errors);

		await _signupCodeRepository.UseCodeAsync(register.SignupCode, register.UserName);

		return new ApiUserDto
		{
			Token = await _tokenService.GenerateTokenAsync(user),
			UserName = user.UserName
		};
	}

	[Authorize]
	[HttpPost(Routes.V1.Auth.Refresh)]
	public async Task<ActionResult<ApiUserDto>> Refresh()
	{
		string username = User.GetUsername();
		ApiUser? user = await _userRepository.GetByUsernameAsync(username);
		string? token = await _tokenService.GenerateTokenAsync(user);

		return new ApiUserDto
		{
			Token = token,
			UserName = user.UserName
		};
	}
}