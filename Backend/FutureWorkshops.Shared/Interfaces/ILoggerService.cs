using FutureWorkshops.Shared.Enums;

namespace FutureWorkshops.Shared.Interfaces
{
	public interface ILoggerService
	{
		#region Methods
		void Log(string content, LogType type, string customFileName = null);
		void LogError(string content);
		void LogError(Exception ex);
		void LogInfo(string content, string customFileName = null);
		void LogText(string content, string customFileName = null);
		void LogWarning(string content, string customFileName = null);
		#endregion
	}
}
