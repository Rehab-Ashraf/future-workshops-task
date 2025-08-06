using System.Runtime.Serialization;
namespace FutureWorkshops.Shared.Models.Exceptions
{
	public class BaseException : ApplicationException
	{
		#region Constructors

		public BaseException()
		{

		}

		public BaseException(string message)
			: base(message)
		{

		}

		public BaseException(string message, Exception innerException)
			: base(message, innerException)
		{

		}

		protected BaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{

		}
		public BaseException(int errorCode)
			: base(errorCode.ToString())
		{
			ErrorCode = errorCode;
		}
		public BaseException(int errorCode, string message)
		: base(message)
		{
			ErrorCode = errorCode;
		}

		#endregion

		public int ErrorCode { get; set; }
	}
}
