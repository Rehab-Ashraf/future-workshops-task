using FutureWorkshops.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Models.ViewModels
{
	public class WorkItemViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public DateTime DueDate { get; set; }
		public WorkItemStatusEnum Status { get; set; }
	}
}
