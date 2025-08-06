using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Shared.Models.ViewModels;
using AutoMapper;

namespace FutureWorkshops.Business
{
	public class Profile : AutoMapper.Profile
	{
		#region Constructors
		public Profile()
		{
			CreateMap<WorkItem, WorkItemViewModel>().ReverseMap();

		}

		#endregion
	}
}
