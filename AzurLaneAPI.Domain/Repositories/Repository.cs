using System.Linq.Expressions;
using AzurLaneAPI.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Domain.Repositories;

public class Repository<TEntity, TIdType> : IRepository<TEntity, TIdType> where TEntity : class
{
	protected readonly DataContext Context;

	public Repository(DataContext context)
	{
		Context = context;
	}

	public async Task<TEntity> GetAsync(TIdType id) =>
		await Context.Set<TEntity>().FindAsync(id) ?? throw new KeyNotFoundException();

	public async Task<IEnumerable<TEntity>> GetAsync() => await Context.Set<TEntity>().ToListAsync();

	public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
		await Context.Set<TEntity>().Where(predicate).ToListAsync();

	public async Task AddAsync(TEntity entity)
	{
		await Context.Set<TEntity>().AddAsync(entity);
	}

	public async Task AddRangeAsync(IEnumerable<TEntity> entities)
	{
		await Context.Set<TEntity>().AddRangeAsync(entities);
	}

	public void Remove(TEntity entity)
	{
		Context.Set<TEntity>().Remove(entity);
	}

	public void RemoveRange(IEnumerable<TEntity> entities)
	{
		Context.Set<TEntity>().RemoveRange(entities);
	}

	public void Update(TEntity entity)
	{
		Context.Set<TEntity>().Update(entity);
	}

	public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();

	public async Task<bool> Exists(TIdType id) => await Context.Set<TEntity>().FindAsync(id) != null;
}