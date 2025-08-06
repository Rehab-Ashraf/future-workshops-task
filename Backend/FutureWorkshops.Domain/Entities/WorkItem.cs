using FutureWorkshops.Shared.Enums;
using FutureWorkshops.Shared.Interfaces;

namespace FutureWorkshops.Domain.Entities
{
	public class WorkItem : IEntityIdentity<int>, IDeletionSignature
	{
		#region IEntityIdentity<int>
		public int Id { get; set; }
		#endregion
		#region IDeletionSignature
		public bool IsDeleted { get; set; }
		public DateTime? DeletionDate { get; set; }
		#endregion
		public string Name { get; set; }
		public DateTime DueDate { get; set; }
		public WorkItemStatusEnum Status  { get; set; }
	}
}
