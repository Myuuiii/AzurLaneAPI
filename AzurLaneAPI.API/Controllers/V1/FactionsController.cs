using AutoMapper;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.Faction;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.API.Controllers.V1;

[AllowAnonymous]
[Route(Routes.V1.Factions.Base)]
public class FactionsController : V1BaseController
{
	private readonly IFactionRepository _factionRepository;

	public FactionsController(DataContext ctx, IMapper mapper, IFactionRepository factionRepository) : base(ctx, mapper)
	{
		_factionRepository = factionRepository;
	}

	[HttpGet(Routes.V1.Factions.GetAll)]
	public async Task<ActionResult<IEnumerable<FactionDto>>> GetAll()
	{
		return Ok(Mapper.Map<IEnumerable<FactionDto>>(await _factionRepository.GetAsync()));
	}

	[HttpGet(Routes.V1.Factions.GetSingleById)]
	public async Task<ActionResult<FactionDto>> GetSingleById(Guid id)
	{
		if (!await _factionRepository.Exists(id))
			return NotFound();
		return Ok(Mapper.Map<FactionDto>(await _factionRepository.GetAsync(id)));
	}

	[HttpGet(Routes.V1.Factions.GetSingleByName)]
	public async Task<ActionResult<FactionDto>> GetSingleByName(string name)
	{
		if (!await _factionRepository.ExistsWithNameAsync(name))
			return NotFound();
		return Ok(Mapper.Map<FactionDto>(await _factionRepository.GetByNameAsync(name)));
	}

	[HttpPost(Routes.V1.Factions.Create)]
	public async Task<ActionResult> Create([FromBody] FactionCreateDto faction)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (await _factionRepository.ExistsWithNameAsync(faction.Name))
			return Conflict("Faction with that name already exists");

		Faction factionEntity = Mapper.Map<Faction>(faction);
		await _factionRepository.AddAsync(factionEntity);
		await Context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSingleById), new { id = factionEntity.Id }, factionEntity.Id);
	}

	[HttpPut(Routes.V1.Factions.Update)]
	public async Task<ActionResult> Update(Guid id, [FromBody] FactionUpdateDto faction)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await _factionRepository.Exists(id))
			return NotFound();

		if (await _factionRepository.ExistsWithNameAsync(faction.Name))
		{
			Faction possiblyConflictingFaction = await _factionRepository.GetByNameAsync(faction.Name);
			if (possiblyConflictingFaction.Id != id)
				return Conflict("Faction with that name already exists");
		}

		Faction existingFaction = await _factionRepository.GetAsync(id);
		Mapper.Map(faction, existingFaction);
		_factionRepository.Update(existingFaction);
		await Context.SaveChangesAsync();

		return AcceptedAtAction(nameof(GetSingleById), new { id }, id);
	}

	[HttpDelete(Routes.V1.Factions.Delete)]
	public async Task<ActionResult> Delete(Guid id)
	{
		if (!await _factionRepository.Exists(id))
			return NotFound();

		Faction existingFaction = await _factionRepository.GetAsync(id);
		_factionRepository.Remove(existingFaction);
		await Context.SaveChangesAsync();

		return NoContent();
	}
}