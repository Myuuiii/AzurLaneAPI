using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.ShipType;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

[Route(Routes.V1.ShipTypes.Base)]
public class ShipTypesController : V1BaseController
{
	private readonly IShipTypeRepository _shipTypeRepository;

	public ShipTypesController(DataContext ctx, IMapper mapper, IShipTypeRepository shipTypeRepository) : base(ctx,
		mapper)
	{
		_shipTypeRepository = shipTypeRepository;
	}

	[HttpGet(Routes.V1.ShipTypes.GetAll)]
	public async Task<ActionResult<IEnumerable<ShipTypeDto>>> GetAll()
	{
		return Ok(Mapper.Map<IEnumerable<ShipTypeDto>>(await _shipTypeRepository.GetAsync()));
	}

	[HttpGet(Routes.V1.ShipTypes.GetSingleById)]
	public async Task<ActionResult<ShipTypeDto>> GetSingleById(Guid id)
	{
		if (!await _shipTypeRepository.Exists(id))
			return NotFound();

		return Ok(Mapper.Map<ShipTypeDto>(await _shipTypeRepository.GetAsync(id)));
	}

	[HttpGet(Routes.V1.ShipTypes.GetSingleByName)]
	public async Task<ActionResult<ShipTypeDto>> GetSingleByName(string name)
	{
		if (!await _shipTypeRepository.ExistsWithNameAsync(name))
			return NotFound();

		return Ok(Mapper.Map<ShipTypeDto>(await _shipTypeRepository.GetByNameAsync(name)));
	}

	[HttpPost(Routes.V1.ShipTypes.Create)]
	public async Task<ActionResult> Create([FromBody] ShipTypeCreateDto shipType)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		
		if (await _shipTypeRepository.ExistsWithNameAsync(shipType.Name))
			return Conflict("Ship type with that name already exists");

		ShipType shipTypeEntity = Mapper.Map<ShipType>(shipType);
		await _shipTypeRepository.AddAsync(shipTypeEntity);
		await Context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSingleById), new { id = shipTypeEntity.Id }, shipTypeEntity.Id);
	}

	[HttpPut(Routes.V1.ShipTypes.Update)]
	public async Task<ActionResult> Update(Guid id, [FromBody] ShipTypeUpdateDto shipType)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _shipTypeRepository.Exists(id))
			return NotFound();

		if (await _shipTypeRepository.ExistsWithNameAsync(shipType.Name))
		{
			ShipType possiblyConflictingShipType = await _shipTypeRepository.GetByNameAsync(shipType.Name);
			if (possiblyConflictingShipType.Id != id)
				return Conflict("Ship type with that name already exists");
		}

		ShipType existingShipType = await _shipTypeRepository.GetAsync(id);
		Mapper.Map(shipType, existingShipType);
		_shipTypeRepository.Update(existingShipType);
		await Context.SaveChangesAsync();

		return AcceptedAtAction(nameof(GetSingleById), new { id }, id);
	}

	[HttpDelete(Routes.V1.ShipTypes.Delete)]
	public async Task<ActionResult> Delete(Guid id)
	{
		if (!await _shipTypeRepository.Exists(id))
			return NotFound();

		ShipType existingShipType = await _shipTypeRepository.GetAsync(id);
		_shipTypeRepository.Remove(existingShipType);
		await Context.SaveChangesAsync();

		return NoContent();
	}
}