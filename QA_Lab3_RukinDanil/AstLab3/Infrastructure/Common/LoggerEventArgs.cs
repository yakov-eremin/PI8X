using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Infrastructure.Common
{
	/// <summary>
	/// Объект аргументов события <seealso cref="Models.Services.Interfaces.ILogger.RegisterLogMessage"/> 
	/// логгера <seealso cref="Models.Services.Interfaces.ILogger"/>
	/// </summary>
	public class LoggerEventArgs : EventArgs
	{
		private LogMessage _logMessage;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="message">Сообщение для логгирования</param>
		public LoggerEventArgs(string message)
		{
			_logMessage = new LogMessage(message);
		}
		/// <summary>
		/// Сообщение для логгирования
		/// </summary>
		public string Message { get => _logMessage.Message; set => _logMessage.Message = value; }
	}
}
