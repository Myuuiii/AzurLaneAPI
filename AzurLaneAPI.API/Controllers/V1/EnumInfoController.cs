using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

/// <summary>
///     Controller that returns information about some of the types used in this API
/// </summary>
[Route(Routes.V1.EnumInfo.Controller)]
public class EnumInfoController : V1BaseController
{
	public EnumInfoController(DataContext ctx, IMapper mapper) : base(ctx, mapper)
	{
	}

	[AllowAnonymous]
	[HttpGet(Routes.V1.EnumInfo.Armor)]
	public async Task<ActionResult<IEnumerable<string>>> GetArmorType()
	{
		return Ok(Enum.GetNames(typeof(Armor)).Select((name, value) => $"{name} = {value}"));
	}

	[AllowAnonymous]
	[HttpGet(Routes.V1.EnumInfo.Rarity)]
	public async Task<ActionResult<IEnumerable<string>>> GetRarityType()
	{
		return Ok(Enum.GetNames(typeof(Rarity)).Select((name, value) => $"{name} = {value}"));
	}
}