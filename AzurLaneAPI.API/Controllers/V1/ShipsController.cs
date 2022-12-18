using AutoMapper;
using AzurLaneAPI.Domain.APIQueryParameters;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.Ship;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

[Route(Routes.V1.Ships.Controller)]
public class ShipsController : V1BaseController
{
	private readonly IFactionRepository _factionRepository;
	private readonly IShipRepository _shipRepository;
	private readonly IShipTypeRepository _shipTypeRepository;
	private readonly IShipTypeSubclassRepository _shipTypeSubclassRepository;

	public ShipsController(DataContext ctx, IMapper mapper, IShipRepository shipRepository,
		IShipTypeRepository shipTypeRepository, IFactionRepository factionRepository,
		IShipTypeSubclassRepository shipTypeSubclassRepository) : base(ctx, mapper)
	{
		_shipTypeSubclassRepository = shipTypeSubclassRepository;
		_factionRepository = factionRepository;
		_shipTypeRepository = shipTypeRepository;
		_shipRepository = shipRepository;
	}

	[AllowAnonymous]
	[HttpGet(Routes.V1.Ships.GetAll)]
	public async Task<ActionResult<IEnumerable<ShipDto>>> GetAll([FromQuery] PaginationParameters pageParams) =>
		Ok(Mapper.Map<IEnumerable<ShipDto>>(await _shipRepository.GetAsync(pageParams)));

	[AllowAnonymous]
	[HttpGet(Routes.V1.Ships.GetSingleById)]
	public async Task<ActionResult<ShipDto>> GetSingleById(string id)
	{
		if (!await _shipRepository.Exists(id))
			return NotFound();

		return Ok(Mapper.Map<ShipDto>(await _shipRepository.GetAsync(id)));
	}

	[AllowAnonymous]
	[HttpGet(Routes.V1.Ships.GetSingleByName)]
	public async Task<ActionResult<ShipDto>> GetSingleByName(string name)
	{
		if (!await _shipRepository.ExistsWithNameAsync(name))
			return NotFound();

		return Ok(Mapper.Map<ShipDto>(await _shipRepository.GetByNameAsync(name)));
	}

	[AllowAnonymous]
	[HttpGet(Routes.V1.Ships.Minimal)]
	public async Task<ActionResult<IEnumerable<MinimalShipDataDto>>> GetMinimalShips(
		[FromQuery] PaginationParameters pageParams) =>
		Ok(await _shipRepository.GetMinimalAsync(pageParams));

	[Authorize(Policy = IdentityNames.Policies.RequireContributorRole)]
	[HttpPost(Routes.V1.Ships.Create)]
	public async Task<ActionResult> Create([FromBody] ShipCreateDto ship)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _shipTypeRepository.Exists(ship.TypeId))
			return NotFound("Ship type not found");
		ShipType shipType = await _shipTypeRepository.GetAsync(ship.TypeId);

		if (!await _factionRepository.Exists(ship.FactionId))
			return NotFound("Faction not found");
		Faction faction = await _factionRepository.GetAsync(ship.FactionId);

		if (!await _shipTypeSubclassRepository.ExistsForShipTypeAsync(shipType.Id, ship.SubclassId))
			return NotFound("Subclass not found within ship type");
		ShipTypeSubclass subclass = await _shipTypeSubclassRepository.GetAsync(ship.SubclassId);

		Ship shipEntity = Mapper.Map<Ship>(ship);
		shipEntity.Faction = faction;
		shipEntity.Type = shipType;
		shipEntity.Subclass = subclass;

		await _shipRepository.AddAsync(shipEntity);
		await Context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSingleById), new { id = shipEntity.Id }, shipEntity.Id);
	}

	[Authorize(Policy = IdentityNames.Policies.RequireContributorRole)]
	[HttpPut(Routes.V1.Ships.Update)]
	public async Task<ActionResult> Update(string id, [FromBody] ShipUpdateDto ship)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _shipRepository.Exists(id))
			return NotFound();
		
		if (!await _shipTypeRepository.Exists(ship.TypeId))
			return NotFound("Ship type not found");
		ShipType shipType = await _shipTypeRepository.GetAsync(ship.TypeId);

		if (!await _factionRepository.Exists(ship.FactionId))
			return NotFound("Faction not found");
		Faction faction = await _factionRepository.GetAsync(ship.FactionId);

		if (!await _shipTypeSubclassRepository.ExistsForShipTypeAsync(shipType.Id, ship.SubclassId))
			return NotFound("Subclass not found within ship type");
		
		ShipTypeSubclass subclass = await _shipTypeSubclassRepository.GetAsync(ship.SubclassId);

		Ship existingShip = await _shipRepository.GetAsync(id);
		existingShip.Type = shipType;
		existingShip.Faction = faction;
		existingShip.Subclass = subclass;

		Mapper.Map(ship, existingShip);
		_shipRepository.Update(existingShip);
		await Context.SaveChangesAsync();

		return AcceptedAtAction(nameof(GetSingleById), new { id }, id);
	}

	[Authorize(Policy = IdentityNames.Policies.RequireContributorRole)]
	[HttpDelete(Routes.V1.Ships.Delete)]
	public async Task<ActionResult> Delete(string id)
	{
		if (!await _shipRepository.Exists(id))
			return NotFound();

		Ship existingShip = await _shipRepository.GetAsync(id);
		_shipRepository.Remove(existingShip);
		await Context.SaveChangesAsync();

		return NoContent();
	}
}