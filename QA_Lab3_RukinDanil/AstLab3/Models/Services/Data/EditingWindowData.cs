using AstLab3.Models.Schedules;
using AstLab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Data
{
	/// <summary>
	/// Данные для использования в <see cref="ViewModels.EditWindowViewModel"/>
	/// </summary>
	public class EditingWindowData
	{
		/// <summary>
		/// Список событий для редактирования.
		/// </summary>
		public List<Vertex> Vertices { get; set; }
		/// <summary>
		/// Указывает, каким образом <see cref="ViewModels.EditWindowViewModel"/> следует обрабатывать данные 
		/// </summary>
		public EditingMode EditingMode { get; set; }
		/// <summary>
		/// Указывает, какое действие предпочтительнее выполнить пользователю.
		/// </summary>
		public PreferedAction PreferedAction { get; set; }
		/// <summary>
		/// Возвращает или задает смысловой контекст работы окна <see cref="Views.Windows.EditWindow"/>
		/// </summary>
		public string MeaningLine { get; set; }
		/// <summary>
		/// Создает объект данных <see cref="EditingWindowData"/> для использования в <see cref="ViewModels.EditWindowViewModel"/>
		/// со списком событий для редактирования, способом обрабобтки данных, смысловым контекстом и предпочитаемым действием.
		/// </summary>
		/// <param name="vertices">Список событий для обработки</param>
		/// <param name="editingMode">Режим работы <see cref="Views.Windows.EditWindow"/></param>
		/// <param name="meaningLine">Смысловой контекст</param>
		/// <param name="preferedAction">Предпочитаемое действие, которое следует выполнить польователю</param>
		public EditingWindowData(List<Vertex> vertices, EditingMode editingMode,
			string meaningLine, PreferedAction preferedAction = PreferedAction.AddFakeVertex)
		{
			Vertices = vertices;
			EditingMode = editingMode;
			PreferedAction = preferedAction;
			MeaningLine = meaningLine;
		}
	}
	/// <summary>
	/// Определяет предпочитаемые для пользователя действия в окне <see cref="Views.Windows.EditWindow"/>
	/// </summary>
	public enum PreferedAction
	{
		AddFakeVertex,
		DeleteVertices,
		DeleteWorks
	}
}
