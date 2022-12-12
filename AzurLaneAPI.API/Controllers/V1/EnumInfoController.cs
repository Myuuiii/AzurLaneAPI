using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

/// <summary>
///     Controller that returns information about some of the types used in this API
/// </summary>
[Route(Routes.V1.EnumInfo.Base)]
public class EnumInfoController : V1BaseController
{
	public EnumInfoController(DataContext ctx, IMapper mapper) : base(ctx, mapper)
	{
	}

	[HttpGet(Routes.V1.EnumInfo.Armor)]
	public async Task<ActionResult<IEnumerable<string>>> GetArmorType()
	{
		return Ok(Enum.GetNames(typeof(Armor)).Select((name, value) => $"{name} = {value}"));
	}

	[HttpGet(Routes.V1.EnumInfo.Rarity)]
	public async Task<ActionResult<IEnumerable<string>>> GetRarityType()
	{
		return Ok(Enum.GetNames(typeof(Rarity)).Select((name, value) => $"{name} = {value}"));
	}
}