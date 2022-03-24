using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Infrastructure.Common
{
	/// <summary>
	/// Класс-обертка над обычной строкой. Предназначен для инкапсуляции логики конструирования лог-сообщения.
	/// </summary>
	public class LogMessage
	{
		private string _message;
		/// <summary>
		/// Сообщение для логгирования.
		/// </summary>
		/// <value>Сообщение, дополненное датой и временем поступления.</value>
		public string Message { get => $"{DateTime.Now}: {_message}"; set => _message = value; }
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="message">Сообщение для логгирования</param>
		public LogMessage(string message)
		{
			Message = message;
		}
	}
}
