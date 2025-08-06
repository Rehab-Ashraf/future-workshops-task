using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using FutureWorkshops.Shared.Interfaces;
using FutureWorkshops.Shared.Models.ViewModels;
using FutureWorkshops.Shared.Common;
using FutureWorkshops.Business.IRepositories.Base;


namespace FutureWorkshops.Infrastructure.Repositories
{

	public class BaseRepositoryAsync<TEntity, TPrimeryKey> :
		IDisposable,
		IAsyncDisposable,
		IBaseRepositoryAsync<TEntity, TPrimeryKey>
		where TEntity : class, IEntityIdentity<TPrimeryKey>
	{

		protected DbContext _context;

		#region Constructors

		public BaseRepositoryAsync(
			DbContext context
			)
		{
			this.Context = context;
		}
		#endregion

		public void Dispose()
		{
			this._context.Dispose();
		}

		public ValueTask DisposeAsync()
		{
			return this._context.DisposeAsync();
		}

		#region Properties

		protected DbContext Context
		{
			get { return this._context; }
			set
			{
				this._context = value;
				this.Entities = this._context.Set<TEntity>();
			}
		}
	

		protected DbSet<TEntity> Entities { get; set; }
		#endregion

		#region IBaseRepository<TEntity, TPrimeryKey>
		public async Task<Pagination> SetPaginationCountAsync(IQueryable<TEntity> source, Pagination pagination)
		{
			if (pagination != null)
			{
				pagination.TotalCount = await source.LongCountAsync();
			}

			return pagination;
		}
       

        public async Task<IQueryable<TEntity>> SetPaginationAsync(IQueryable<TEntity> source, Pagination pagination)
		{
			return await Task.Run(() =>
			{
				if (source != null &&
					pagination != null &&
					pagination.PageIndex.HasValue &&
					pagination.PageSize.HasValue)
				{
					source = source.Skip(pagination.PageIndex.Value * pagination.PageSize.Value)
								   .Take(pagination.PageSize.Value);
				}

				return source;
			});
		}


		public virtual async Task<IQueryable<TEntity>> GetAsync(RepositoryRequestConditionFilter<TEntity, TPrimeryKey> conditionFilter = null)
		{
			return await Task.Run(async () =>
		   {
			   var result = this.Entities.AsQueryable();

			   if (conditionFilter != null)
			   {
				   #region Set Count
				   conditionFilter.Pagination = await SetPaginationCountAsync(result, conditionFilter.Pagination);
				   #endregion

				   #region Set Pagination
				   result = await SetPaginationAsync(result, conditionFilter.Pagination);
				   #endregion
			   }

			   return result;

		   });
		}

		public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string[] includedNavigationsList = null)
		{
			var repo = this.Entities.AsQueryable();
			TEntity result = null;

			#region Set IncludedNavigationsList
			if (includedNavigationsList != null)
			{
				for (int i = 0; i < includedNavigationsList.Length; i++)
				{
					repo = repo.Include(includedNavigationsList[i]);
				}
			}
			#endregion

			#region Set Where Clause
			if (predicate != null)
			{
				result = await repo.FirstOrDefaultAsync(predicate);
			}
			#endregion

			return result;
		}

		public virtual async Task<TEntity> GetAsync(TPrimeryKey id)
		{
			var result = await this.Entities.FindAsync(id);
			return result;
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			await this.Entities.AddAsync(entity);
			return entity;
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			return await Task.Run(() =>
			{
				this.Entities.Update(entity);
				return entity;
			});
		}

		public virtual async Task DeleteAsync(TPrimeryKey id)
		{
			await Task.Run(() =>
			{
				var entity = this.Entities.Find(id);

				this.DeleteEntity(entity);
			});
		}

		

		private void DeleteEntity(TEntity entity)
		{
			if (entity is IDeletionSignature)
			{
				DateTime now = DateTime.UtcNow;
				var virtualDeleteEntity = (IDeletionSignature)entity;

				virtualDeleteEntity.IsDeleted = true;
				virtualDeleteEntity.DeletionDate = now;

				this.Entities.Update(entity);
			}
			else
			{
				this.Entities.Remove(entity);
			}
		}
        #endregion
    }
}
