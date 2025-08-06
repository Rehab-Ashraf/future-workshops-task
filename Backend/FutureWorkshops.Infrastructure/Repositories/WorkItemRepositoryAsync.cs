using FutureWorkshops.Business.IRepositories;
using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Infrastructure.Contexts;

namespace FutureWorkshops.Infrastructure.Repositories
{
	public class WorkItemRepositoryAsync : BaseServiceRepositoryAsync<WorkItem, int>, IWorkItemRepositoryAsync
	{
		#region Constructors
		public WorkItemRepositoryAsync(FutureWorkshopsContext context)
			: base(context)
		{

		}
		#endregion
	}
}
