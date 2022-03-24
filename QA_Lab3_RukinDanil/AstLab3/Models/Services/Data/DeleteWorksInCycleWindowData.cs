using AstLab3.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Data
{
	/// <summary>
	/// Данные для <see cref="ViewModels.DeleteWorksInCycleWindowViewModel"/>
	/// </summary>
	public class DeleteWorksInCycleWindowData
	{
		/// <summary>
		/// Коллекция работ в цикле.
		/// </summary>
		public List<Work> WorksInCycle { get; set; }
		/// <summary>
		/// Создает объект данных <see cref="DeleteWorksInCycleWindowData"/> для использования в
		/// <see cref="ViewModels.DeleteWorksInCycleWindowViewModel"/> со списком работ в цикле.
		/// </summary>
		/// <param name="worksInCycle">Список работ в цикле</param>
		public DeleteWorksInCycleWindowData(List<Work> worksInCycle)
		{
			WorksInCycle = worksInCycle;
		}
	}
}
