using AutoMapper;
using AzurLaneAPI.Domain.APIQueryParameters;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Dtos.Ship;
using AzurLaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class ShipRepository : Repository<Ship, string>, IShipRepository
{
	private readonly IMapper _mapper;

	public ShipRepository(DataContext context, IMapper mapper) : base(context)
	{
		_mapper = mapper;
	}

	public new async Task<IEnumerable<Ship>> GetAsync()
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.ToListAsync();
	}

	public new async Task<Ship> GetAsync(string id)
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.FirstAsync(x => x.Id == id);
	}

	public async Task<bool> ExistsWithNameAsync(string name)
	{
		return await Context.Ships
			.AnyAsync(x => x.EnglishName == name || x.JapaneseName == name || x.ChineseName == name);
	}

	public async Task<Ship> GetByNameAsync(string name)
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.FirstAsync(x => x.EnglishName == name || x.JapaneseName == name || x.ChineseName == name);
	}

	public async Task<IEnumerable<MinimalShipDataDto>> GetMinimalAsync(PaginationParameters parameters) =>
		await _mapper.ProjectTo<MinimalShipDataDto>(Context.Ships
			.Skip((parameters.PageNumber - 1) * parameters.PageSize)
			.Take(parameters.PageSize)).ToListAsync();

	public async Task<IEnumerable<Ship>> GetAsync(PaginationParameters parameters)
	{
		return await Context.Ships
			.Include(x => x.Faction)
			.Include(x => x.BaseStats)
			.Include(x => x.Level100Stats)
			.Include(x => x.Level120Stats)
			.Include(x => x.Level125Stats)
			.Include(x => x.Type)
			.Include(x => x.Subclass)
			.Skip((parameters.PageNumber - 1) * parameters.PageSize)
			.Take(parameters.PageSize)
			.ToListAsync();
	}
}