using FutureWorkshops.Business.IServices;
using FutureWorkshops.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FutureWorkshops.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkItemController : ControllerBase
	{
		#region Data Members
		private readonly IWorkItemService _workItemService;
		#endregion

		#region Constructors
		public WorkItemController(
			IWorkItemService storeService

			)
		{
			this._workItemService = storeService;
		}
		#endregion

		#region Actions
		#region get

		[Route("GetByID/{id}")]
		[HttpGet]		
		public async Task<WorkItemViewModel> GetByID(int id)
		{
			var result = await this._workItemService.GetAsync(id);
			return result;
		}

		[Route("Search")]
		[HttpPost]
		public async Task<GenericResult<List<WorkItemViewModel>>> Search(WorkItemSearchModel searchModel)
		{
			var result = await this._workItemService.Search(searchModel);
			return result;
		}
		#endregion

		#region post
		[Route("Add")]
		[HttpPost]
		public async Task<int> Add(WorkItemViewModel model)
		{
			var result = await this._workItemService.AddAsync(model);
			return result;
		}
		#endregion

		#region update
		[Route("Update")]
		[HttpPut]
		public async Task<int> Update(WorkItemViewModel model)
		{
			var result = await this._workItemService.UpdateAsync(model);
			return result;
		}
		#endregion

		#region delete

		[Route("Delete")]
		[HttpDelete]
		public async Task<bool> Delete(int id)
		{
			var result = await this._workItemService.DeleteAsync(id);
			return result;
		}
		#endregion
		#endregion
	}
}
