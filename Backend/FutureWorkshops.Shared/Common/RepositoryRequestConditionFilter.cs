
using System.Linq.Expressions;

namespace FutureWorkshops.Shared.Common
{
	public class RepositoryRequestConditionFilter<TEntity, TKey> : RepositoryRequest
	{

		#region Constructors
		public RepositoryRequestConditionFilter(RepositoryRequest repositoryRequest)
			: base(repositoryRequest)
		{

		}
		public RepositoryRequestConditionFilter()
		{

		}
		#endregion

		#region Properties
		public Expression<Func<TEntity, bool>> Query { get; set; }
		#endregion
	}
}
