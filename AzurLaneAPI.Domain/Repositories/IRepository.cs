using System.Linq.Expressions;

namespace AzurLaneAPI.Domain.Repositories;

public interface IRepository<TEntity, in TIdType> where TEntity : class
{
	Task<TEntity> GetAsync(TIdType id);
	Task<IEnumerable<TEntity>> GetAsync();
	Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

	Task AddAsync(TEntity entity);
	Task AddRangeAsync(IEnumerable<TEntity> entities);

	void Remove(TEntity entity);
	void RemoveRange(IEnumerable<TEntity> entities);

	void Update(TEntity entity);

	Task<int> SaveChangesAsync();
	Task<bool> Exists(TIdType id);
}