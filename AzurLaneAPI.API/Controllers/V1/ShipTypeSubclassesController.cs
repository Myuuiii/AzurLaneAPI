using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.ShipTypeSubclass;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

[Route(Routes.V1.ShipTypeSubclasses.Base)]
public class ShipTypeSubclassesController : V1BaseController
{
	private readonly IShipTypeRepository _shipTypeRepository;
	private readonly IShipTypeSubclassRepository _shipTypeSubclassRepository;

	public ShipTypeSubclassesController(DataContext ctx, IMapper mapper,
		IShipTypeSubclassRepository shipTypeSubclassRepository, IShipTypeRepository shipTypeRepository) : base(ctx,
		mapper)
	{
		_shipTypeRepository = shipTypeRepository;
		_shipTypeSubclassRepository = shipTypeSubclassRepository;
	}

	[HttpGet(Routes.V1.ShipTypeSubclasses.GetAll)]
	public async Task<ActionResult<IEnumerable<ShipTypeSubclassDto>>> GetAll()
	{
		return Ok(Mapper.Map<IEnumerable<ShipTypeSubclassDto>>(await _shipTypeSubclassRepository.GetAsync()));
	}

	[HttpGet(Routes.V1.ShipTypeSubclasses.GetSingleById)]
	public async Task<ActionResult<ShipTypeSubclassDto>> GetSingleById(Guid id)
	{
		if (!await _shipTypeSubclassRepository.Exists(id))
			return NotFound();
		return Ok(Mapper.Map<ShipTypeSubclassDto>(await _shipTypeSubclassRepository.GetAsync(id)));
	}

	[HttpGet(Routes.V1.ShipTypeSubclasses.GetSingleByName)]
	public async Task<ActionResult<ShipTypeSubclassDto>> GetSingleByName(string name)
	{
		if (!await _shipTypeSubclassRepository.ExistsWithNameAsync(name))
			return NotFound();
		return Ok(Mapper.Map<ShipTypeSubclassDto>(await _shipTypeSubclassRepository.GetByNameAsync(name)));
	}

	[HttpPost(Routes.V1.ShipTypeSubclasses.Create)]
	public async Task<ActionResult> Create([FromBody] ShipTypeSubclassCreateDto shipTypeSubclass)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _shipTypeRepository.Exists(shipTypeSubclass.ShipTypeId))
			return NotFound("ShipType not found");
		ShipType shipType = await _shipTypeRepository.GetAsync(shipTypeSubclass.ShipTypeId);

		if (await _shipTypeSubclassRepository.ExistsWithNameAsync(shipTypeSubclass.Name))
			return Conflict("Ship Type Subclass with that name already exists");

		ShipTypeSubclass shipTypeSubclassEntity = Mapper.Map<ShipTypeSubclass>(shipTypeSubclass);
		shipTypeSubclassEntity.ShipType = shipType;
		await _shipTypeSubclassRepository.AddAsync(shipTypeSubclassEntity);
		await Context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSingleById), new { id = shipTypeSubclassEntity.Id },
			shipTypeSubclassEntity.Id);
	}

	[HttpPut(Routes.V1.ShipTypeSubclasses.Update)]
	public async Task<ActionResult> Update(Guid id, [FromBody] ShipTypeSubclassUpdateDto shipTypeSubclass)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _shipTypeSubclassRepository.Exists(id))
			return NotFound();

		if (!await _shipTypeRepository.Exists(shipTypeSubclass.ShipTypeId))
			return NotFound("ShipType not found");
		ShipType shipType = await _shipTypeRepository.GetAsync(shipTypeSubclass.ShipTypeId);

		if (await _shipTypeSubclassRepository.ExistsWithNameAsync(shipTypeSubclass.Name))
		{
			ShipTypeSubclass possiblyConflictingShipTypeSubclass =
				await _shipTypeSubclassRepository.GetByNameAsync(shipTypeSubclass.Name);
			if (possiblyConflictingShipTypeSubclass.Id != id)
				return Conflict("Ship Type Subclass with that name already exists");
		}

		ShipTypeSubclass existingShipTypeSubclass = Mapper.Map<ShipTypeSubclass>(shipTypeSubclass);
		existingShipTypeSubclass.ShipType = shipType;
		Mapper.Map(shipTypeSubclass, existingShipTypeSubclass);
		_shipTypeSubclassRepository.Update(existingShipTypeSubclass);
		await Context.SaveChangesAsync();

		return AcceptedAtAction(nameof(GetSingleById), new { id }, id);
	}

	[HttpDelete(Routes.V1.ShipTypeSubclasses.Delete)]
	public async Task<ActionResult> Delete(Guid id)
	{
		if (!await _shipTypeSubclassRepository.Exists(id))
			return NotFound();

		ShipTypeSubclass shipTypeSubclass = await _shipTypeSubclassRepository.GetAsync(id);
		_shipTypeSubclassRepository.Remove(shipTypeSubclass);
		await Context.SaveChangesAsync();

		return NoContent();
	}
}