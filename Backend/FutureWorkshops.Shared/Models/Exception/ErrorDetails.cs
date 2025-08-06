
namespace FutureWorkshops.Shared.Models.Exceptions
{
	public class ErrorDetails
	{
		public override string ToString()
		{
			return (ErrorCode == 0) ? $"{this.StatusCode}, {Message}" : ErrorCode.ToString();
		}
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public int ErrorCode { get; set; }
	}
}
