using FutureWorkshops.Business.IRepositories.Base;
using FutureWorkshops.Infrastructure.Contexts;
using FutureWorkshops.Shared.Interfaces;

namespace FutureWorkshops.Infrastructure.Repositories
{
	public class BaseServiceRepositoryAsync<TEntity, TPrimeryKey> : BaseRepositoryAsync<TEntity, TPrimeryKey>,
		IBaseServiceRepositoryAsync<TEntity, TPrimeryKey>
		where TEntity : class, IEntityIdentity<TPrimeryKey>
	{
		#region Data Members
		private FutureWorkshopsContext _Context;
		#endregion

		#region Constructors
		public BaseServiceRepositoryAsync(FutureWorkshopsContext context)
			: base(context)
		{
			this.Context = context;
		}
		#endregion

		#region Properties
		protected FutureWorkshopsContext Context
		{
			get { return this._Context; }
			private set { this._Context = value; }
		}
		#endregion
	}
}
