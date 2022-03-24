using AstLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Schedules.Exceptions
{
	/// <summary>
	/// Представляет ошибку, которая происоходит, если в сетевом графике не найдена или начальная, или конечная вершина.
	/// </summary>
	public class NoVerticesFoundException : Exception
	{
		/// <summary>
		/// Указывает, какая вершина не была обнаружена.
		/// </summary>
		public EditingMode EditingMode { get; set; }
		/// <summary>
		/// Создает новый экземпляр сущности <see cref="NoVerticesFoundException"/> с сообщением об ошибке и типом необнаруженной вершины.
		/// </summary>
		/// <param name="message">Сообщение об ошибке</param>
		/// <param name="editingMode">Тип необнаруженной вершины</param>
		public NoVerticesFoundException(string message, EditingMode editingMode) : base(message)
		{
			EditingMode = editingMode;
		}
	}
}
