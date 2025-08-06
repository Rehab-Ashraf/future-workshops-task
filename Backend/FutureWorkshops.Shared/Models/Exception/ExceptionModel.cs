using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWorkshops.Shared.Models.Exceptions
{
	public class ExceptionModel
	{
		public DateTime? RequestTime { get; set; }
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public int ErrorCode { get; set; }
	}
}
