using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Models.ViewModels
{
	public class Pagination
	{
		public int? PageIndex { get; set; } = 0;
		public int? PageSize { get; set; } = 10;
		public long? TotalCount { get; set; } = 0;
	}
}
