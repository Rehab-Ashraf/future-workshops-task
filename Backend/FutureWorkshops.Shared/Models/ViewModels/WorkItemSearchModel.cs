using FutureWorkshops.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Models.ViewModels
{
	public class WorkItemSearchModel
	{
		public string? Name { get; set; }
		public WorkItemStatusEnum? Status { get; set; }
		public Pagination Pagination { get; set; }
	}
}
