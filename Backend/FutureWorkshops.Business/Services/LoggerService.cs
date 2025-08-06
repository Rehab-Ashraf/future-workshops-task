using FutureWorkshops.Shared.Enums;
using FutureWorkshops.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Settings.Configuration;
using System.Diagnostics;
namespace FutureWorkshops.Business.Services
{
	public class LoggerService : ILoggerService
	{
		#region Data Members
		private readonly IHttpContextAccessor _httpContext;
		private readonly string _rootPath = "Logs\\";
		private readonly ILogger _logger;
		private IConfiguration _appConfiguration;
		#endregion

		#region Constructors
		public LoggerService(IHttpContextAccessor httpContext, IConfiguration appConfiguration)
		{
			this._httpContext = httpContext;
			this._appConfiguration = appConfiguration;

			_logger = new LoggerConfiguration().
				ReadFrom.Configuration(_appConfiguration, new ConfigurationReaderOptions { SectionName = "Serilog" })
							.MinimumLevel.Debug()
							.CreateLogger();
			_logger.Information("startlogging");
			_logger.Debug("startlogging");
			_logger.Error("startlogging");
			_logger.Warning("startlogging");



		}
		#endregion

		#region ILoggerService
		public void Log(string content, LogType type, string customFileName = null)
		{
			DateTime now = DateTime.UtcNow;

			try
			{
				switch (type)
				{
					case LogType.Information:
						_logger.Information(content);
						break;
					case LogType.Warning:
						_logger.Warning(content);
						break;
					case LogType.Error:
						_logger.Error(content);
						break;
					case LogType.Text:
						_logger.Debug(content);
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				try
				{
					#region Log Exception in EventLog
					EventLog eventLog = new EventLog(this.GetType().FullName, System.Environment.MachineName);

					eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
					#endregion
				}
				catch { }
			}
		}
		public void LogError(string content)
		{
			this.Log(content, LogType.Error);
		}
		public void LogError(Exception ex)
		{
			this.Log(ex.ToString(), LogType.Error);
		}
		public void LogInfo(string content, string customFileName = null)
		{
			this.Log(content, LogType.Information);
		}
		public void LogText(string content, string customFileName = null)
		{
			this.Log(content, LogType.Text);
		}
		public void LogWarning(string content, string customFileName = null)
		{
			this.Log(content, LogType.Warning);
		}

		#endregion
	}
}
