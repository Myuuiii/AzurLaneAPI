using AutoMapper;
using AzurLaneAPI.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

[ApiController]
[Route(Routes.V1.Base)]
public class V1BaseController : ApiControllerBase
{
	public V1BaseController(DataContext ctx, IMapper mapper) : base(ctx, mapper)
	{
	}
}