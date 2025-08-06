
using FutureWorkshops.Shared.Common;
using FutureWorkshops.Shared.Interfaces;
using FutureWorkshops.Shared.Models.ViewModels;
using System.Linq.Expressions;

namespace FutureWorkshops.Business.IRepositories.Base
{
	public interface IBaseRepositoryAsync<TEntity, TPrimeryKey> : IAsyncDisposable
		where TEntity : class, IEntityIdentity<TPrimeryKey>
	{
		Task<IQueryable<TEntity>> SetPaginationAsync(IQueryable<TEntity> source, Pagination pagination);
		Task<Pagination> SetPaginationCountAsync(IQueryable<TEntity> source, Pagination pagination);
		Task<IQueryable<TEntity>> GetAsync(RepositoryRequestConditionFilter<TEntity, TPrimeryKey> conditionFilter = null);
		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string[] includedNavigationsList = null);
		Task<TEntity> GetAsync(TPrimeryKey id);
		Task<TEntity> AddAsync(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity);
		Task DeleteAsync(TPrimeryKey id);
	}
}
