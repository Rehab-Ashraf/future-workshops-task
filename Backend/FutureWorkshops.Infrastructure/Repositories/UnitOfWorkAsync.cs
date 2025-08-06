
using FutureWorkshops.Business.IRepositories;
using FutureWorkshops.Infrastructure.Contexts;

namespace FutureWorkshops.Infrastructure.Repositories
{
	public class UnitOfWorkAsync : IUnitOfWorkAsync
	{
		#region Data Members
		private FutureWorkshopsContext _context;
		#endregion

		#region Constructors

		public UnitOfWorkAsync(FutureWorkshopsContext context)
		{
			this._context = context;
		}
		#endregion

		#region IUnitOfWork	
		public async Task<int> CommitAsync()
		{
			var result = await this._context.SaveChangesAsync();
			return result;
		}
		#endregion
	}
}
