namespace FutureWorkshops.Business.IRepositories
{
	public interface IUnitOfWorkAsync
	{
		Task<int> CommitAsync();
	}
}
