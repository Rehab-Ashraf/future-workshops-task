using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Infrastructure.Seed
{
	public class WorkItemSeed
	{
		static WorkItemSeed() { Seed(); }

		private static void Seed()
		{
			SeedList = new List<WorkItem>();
			List<WorkItem> workItems = new List<WorkItem>
			{
				new WorkItem
				{
					Id = 1,
					Name = "Design homepage UI",
					DueDate = DateTime.Today.AddDays(3),
					Status = WorkItemStatusEnum.NotStarted,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 2,
					Name = "Implement login feature",
					DueDate = DateTime.Today.AddDays(5),
					Status = WorkItemStatusEnum.InProgress,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 3,
					Name = "Write unit tests for backend services",
					DueDate = DateTime.Today.AddDays(7),
					Status = WorkItemStatusEnum.NotStarted,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 4,
					Name = "Deploy initial version to staging",
					DueDate = DateTime.Today.AddDays(10),
					Status = WorkItemStatusEnum.NotStarted,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 5,
					Name = "Fix bugs from QA feedback",
					DueDate = DateTime.Today.AddDays(2),
					Status = WorkItemStatusEnum.InProgress,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 6,
					Name = "Review code and optimize queries",
					DueDate = DateTime.Today.AddDays(4),
					Status = WorkItemStatusEnum.Completed,
					IsDeleted = false
				},
				new WorkItem
				{
					Id = 7,
					Name = "Document API endpoints",
					DueDate = DateTime.Today.AddDays(6),
					Status = WorkItemStatusEnum.NotStarted,
					IsDeleted = false
				}
			};
			SeedList = workItems;
		}

		public static List<WorkItem> SeedList { get; set; }
	}
}
