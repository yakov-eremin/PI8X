using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Schedules.Exceptions
{
	/// <summary>
	/// Представляет ошибку, которая происходит, если в сетевом графике найдены частично совпадающие работы.
	/// </summary>
	public class OverlappingWorksFoundException : Exception
	{
		/// <summary>
		/// Первая из частично совпадающих работ, котрую следует удалить.
		/// </summary>
		public Work FirstWorkToDelete { get; set; }
		/// <summary>
		/// Вторая из частично совпадающих работ, котрую следует удалить.
		/// </summary>
		public Work SecondWorkToDelete { get; set; }
		/// <summary>
		/// Создает новый экземпляр сущности <see cref="OverlappingWorksFoundException"/> с сообщением об ошибке
		/// и двумя частично совпадающими работами
		/// </summary>
		/// <param name="message">Сообщение об ошибке</param>
		/// <param name="firstWorkToDelete">Первая из частично совпадающих работ</param>
		/// <param name="secondWorkToDelete">Вторая из частично совпадающих работ</param>
		public OverlappingWorksFoundException(string message, Work firstWorkToDelete, Work secondWorkToDelete) : base(message)
		{
			FirstWorkToDelete = firstWorkToDelete;
			SecondWorkToDelete = secondWorkToDelete;
		}
	}
}
