using FutureWorkshops.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Common
{
	public class RepositoryRequest
	{
		public RepositoryRequest(RepositoryRequest repositoryRequest)
		{
			if (repositoryRequest != null)
			{
				this.Pagination = repositoryRequest.Pagination;
			}
			
		}
		public RepositoryRequest()
		{
		}


		public Pagination Pagination { get; set; }
	}
}
