using FutureWorkshops.Shared.Interfaces;


namespace FutureWorkshops.Business.IRepositories.Base
{
	public interface IBaseServiceRepositoryAsync<TEntity, TPrimeryKey> : IBaseRepositoryAsync<TEntity, TPrimeryKey>
		where TEntity : class, IEntityIdentity<TPrimeryKey>
	{

	}
}
