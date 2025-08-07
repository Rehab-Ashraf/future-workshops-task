

using FutureWorkshops.Shared.Models.ViewModels;

namespace FutureWorkshops.Business.IServices
{
	public interface IWorkItemService
	{
		#region Methods
		Task ValidateModelAsync(WorkItemViewModel model);
		Task<GenericResult<List<WorkItemViewModel>>> Search(WorkItemSearchModel searchModel);
		Task<WorkItemViewModel> GetAsync(int id);
		Task<int> AddAsync(WorkItemViewModel model);
		Task<int> UpdateAsync(WorkItemViewModel model);
		Task<bool> DeleteAsync(int id);
		#endregion
	}
}
