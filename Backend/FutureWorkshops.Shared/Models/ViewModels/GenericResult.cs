using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Models.ViewModels
{
	public class GenericResult<TCollection>
	{
		public TCollection Collection { get; set; }
		public Pagination Pagination { get; set; }
	}
}
