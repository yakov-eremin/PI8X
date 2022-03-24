using AstLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Schedules.Exceptions
{
	/// <summary>
	/// Представляет ошибку, которая происходит, если в сетевом графике найдены несколько начальных или конечных вершин.
	/// </summary>
	public class SeveralVerticesFoundException : Exception
	{
		/// <summary>
		/// Возвращает список начальных или конечных вершин
		/// </summary>
		public List<Vertex> Vertices { get; set; }
		/// <summary>
		/// Определяет, какие виршины находятся в списке
		/// </summary>
		public EditingMode EditingMode { get; set; }
		/// <summary>
		/// Создает экземпляр сущности <see cref="SeveralVerticesFoundException"/> с сообщением об ошибке,
		/// списком ошибочных вершин и типом этих вершин.
		/// </summary>
		/// <param name="message">Сообщение об ошибке</param>
		/// <param name="vertices">Список ошибочных вершин</param>
		/// <param name="editingMode">Тип вершин: начальные или конченые</param>
		public SeveralVerticesFoundException(string message, List<Vertex> vertices, EditingMode editingMode) : base(message)
		{
			Vertices = vertices;
			EditingMode = editingMode;
		}
	}
}
