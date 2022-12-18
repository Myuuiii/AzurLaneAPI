using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.API.Controllers.V1;

public class AdminController : V1BaseController
{
	private RoleManager<ApiRole> _roleManager;
	private UserManager<ApiUser> _userManager;

	public AdminController(DataContext ctx, IMapper mapper, UserManager<ApiUser> userManager, RoleManager<ApiRole> roleManager) : base(ctx, mapper)
	{
		_userManager = userManager;
		_roleManager = roleManager;
	}
	
	// [Authorize(Policy = IdentityNames.Policies.RequireAdminRole)]
	[HttpGet("users-with-roles")]
	public async Task<ActionResult> GetUsersWithRoles()
	{
		var users = await _userManager.Users
			.OrderBy(x => x.UserName)
			.Select(apiUser => new
			{
				apiUser.Id,
				Username = apiUser.UserName,
				Roles = apiUser.UserRoles
					.Select(apiUserRole => apiUserRole.Role.Name)
					.ToList()
			}).ToListAsync();
		return Ok(users);
	}

	// [Authorize(Policy = IdentityNames.Policies.RequireAdminRole)]
	[HttpPut("edit-roles/{username}")]
	public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
	{
		if (string.IsNullOrEmpty(roles)) return BadRequest("You must select at least one role");
		string[] selectedRoles = roles.Split(",").ToArray();
		
		ApiUser? user = await _userManager.FindByNameAsync(username);
		if (user == null) return NotFound();
		
		IList<string> userRoles = await _userManager.GetRolesAsync(user);
		
		IdentityResult result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
		if (!result.Succeeded) return BadRequest("Failed to add to roles");
		
		result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
		if (!result.Succeeded) return BadRequest("Failed to remove the roles");

		return Ok(await _userManager.GetRolesAsync(user));
	}

}