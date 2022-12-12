using AutoMapper;
using AzurLaneAPI.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers;

public class ApiControllerBase : ControllerBase
{
	protected readonly DataContext Context;
	protected readonly IMapper Mapper;

	public ApiControllerBase(DataContext ctx, IMapper mapper)
	{
		Mapper = mapper;
		Context = ctx;
	}
}