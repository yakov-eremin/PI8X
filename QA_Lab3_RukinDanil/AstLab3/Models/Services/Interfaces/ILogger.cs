using AstLab3.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Interfaces
{
	/// <summary>
	/// Предоставляет функциональность для логгирования происходящих в системе событий.
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Происходит во время логгирования
		/// </summary>
		public event EventHandler<LoggerEventArgs> RegisterLogMessage;
		/// <summary>
		/// Позволяет логгировать события путем передачи сообщения.
		/// </summary>
		/// <param name="message">Сообщение для логгирования</param>
		void LogMessage(string message);
	}
}
