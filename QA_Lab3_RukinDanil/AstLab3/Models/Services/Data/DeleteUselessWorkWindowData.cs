using AstLab3.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Data
{
	/// <summary>
	/// Данные для <see cref="ViewModels.DeleteUselessWorkWindowViewModel"/>
	/// </summary>
	public class DeleteUselessWorkWindowData
	{
		/// <summary>
		/// Первая работа сетевого графика, которую необходимо удалить. Удалить необходимо только одну работу.
		/// </summary>
		public Work FirstWorkToDelete { get; set; }
		/// <summary>
		/// Вторая работа сетевого графика, которую необходимо удалить. Удалить необходимо только одну работу.
		/// </summary>
		public Work SecondWorkToDelete { get; set; }
		/// <summary>
		/// Создает объект данных <see cref="DeleteUselessWorkWindowData"/> для <see cref="ViewModels.DeleteUselessWorkWindowViewModel"/>
		/// с работами для удаления
		/// </summary>
		/// <param name="firstWorkToDelete">Первая работа для удаления</param>
		/// <param name="secondWorkToDelete">Вторая работа для удаления</param>
		public DeleteUselessWorkWindowData(Work firstWorkToDelete, Work secondWorkToDelete)
		{
			FirstWorkToDelete = firstWorkToDelete;
			SecondWorkToDelete = secondWorkToDelete;
		}
	}
}
