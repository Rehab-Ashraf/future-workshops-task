using AutoMapper;
using FutureWorkshops.Business.IRepositories;
using FutureWorkshops.Business.IServices;
using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Shared.Enums;
using FutureWorkshops.Shared.Models.Exceptions;
using FutureWorkshops.Shared.Models.ViewModels;
using System.Reflection;

namespace FutureWorkshops.Business.Services
{
	public class WorkItemService : IWorkItemService
	{
		private readonly IWorkItemRepositoryAsync _WorkItemRepositoryAsync;
		private readonly IMapper _mapper;
		private readonly IUnitOfWorkAsync _unitOfWork;
		public WorkItemService(
			IWorkItemRepositoryAsync workItemRepositoryAsync,
			IMapper mapper,
			IUnitOfWorkAsync unitOfWork)
		{
			_WorkItemRepositoryAsync = workItemRepositoryAsync;
			_mapper = mapper;
			this._unitOfWork = unitOfWork;
		}


		#region Get
		public async Task<WorkItemViewModel> GetAsync(int id)
		{
			var entity = (await _WorkItemRepositoryAsync.GetAsync(conditionFilter: null)).Where(c => c.Id == id && !c.IsDeleted).Select(c => c).FirstOrDefault();
			return _mapper.Map<WorkItem, WorkItemViewModel>(entity);
		}

		public async Task<GenericResult<List<WorkItemViewModel>>> Search(WorkItemSearchModel searchModel)
		{
			var query = (await _WorkItemRepositoryAsync.GetAsync(conditionFilter: null)).Where(a => !a.IsDeleted);

			int total =
				query.Where(x => !x.IsDeleted).Count();

			searchModel = searchModel == null ? new WorkItemSearchModel() : searchModel;

			if (searchModel?.Status != null)
			{
				query = query.Where(i => i.Status == searchModel.Status);
			}
			if (!String.IsNullOrWhiteSpace(searchModel?.Name))
			{
				query = query.Where(i => i.Name.Contains(searchModel.Name));
			}

			searchModel.Pagination = await this._WorkItemRepositoryAsync.SetPaginationCountAsync(query, searchModel.Pagination);
			query = await this._WorkItemRepositoryAsync.SetPaginationAsync(query, searchModel.Pagination);

			var entities = query.Select(a=> _mapper.Map<WorkItem ,WorkItemViewModel>(a));
			var result = new GenericResult<List<WorkItemViewModel>>
			{
				Collection = entities.ToList(),
				Pagination = searchModel.Pagination
			};

			return result;
		}
		#endregion

		#region Post 
		public async Task<int> AddAsync(WorkItemViewModel model)
		{
			await this.ValidateModelAsync(model);
			var entity = _mapper.Map<WorkItemViewModel, WorkItem>(model);
			entity = await _WorkItemRepositoryAsync.AddAsync(entity);
			await _unitOfWork.CommitAsync();

			return entity.Id;
		}
		#endregion

		#region Update
		public async Task<int> UpdateAsync(WorkItemViewModel model)
		{
			await this.ValidateModelAsync(model);
			var entity = _mapper.Map<WorkItemViewModel, WorkItem>(model);
			var query = await this._WorkItemRepositoryAsync.GetAsync(null);
			var oldentity = query.Where(entity => entity.Id == model.Id).FirstOrDefault();
			
			oldentity.Name = entity.Name;
			oldentity.DueDate = entity.DueDate;
			oldentity.Status = entity.Status;
			
			oldentity = await _WorkItemRepositoryAsync.UpdateAsync(oldentity);
			await _unitOfWork.CommitAsync();

			return entity.Id;
		}
		public async Task<bool> ActivateOrDeavtivateAsync(int id)
		{
			var query = await this._WorkItemRepositoryAsync.GetAsync(null);
			var entity = query.Where(entity => entity.Id == id).FirstOrDefault();
 
			entity = await this._WorkItemRepositoryAsync.UpdateAsync(entity);
			await _unitOfWork.CommitAsync();
			return true;
		}
		#endregion

		#region delete
		public async Task<bool> DeleteAsync(int id)
		{
			await _WorkItemRepositoryAsync.DeleteAsync(id);
			await _unitOfWork.CommitAsync();

			return true;
		}

		#endregion
		public async Task ValidateModelAsync(WorkItemViewModel model)
		{
			var existEntity = (await _WorkItemRepositoryAsync.GetAsync(null))
						.FirstOrDefault(entity =>
										 entity.Name == model.Name && !entity.IsDeleted && entity.Id != model.Id);

			if (existEntity != null)
			{
				throw new BaseException((int)ErrorCode.NameAlreadyExist);
			}
		}
	}
}
