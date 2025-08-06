using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Interfaces
{
	public interface IDeletionSignature
	{
		#region Properties
		public bool IsDeleted { get; set; }
		public DateTime? DeletionDate { get; set; }
		#endregion
	}
}
