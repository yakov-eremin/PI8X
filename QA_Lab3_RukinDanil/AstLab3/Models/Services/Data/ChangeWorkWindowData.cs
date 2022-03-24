using AstLab3.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Data
{
	/// <summary>
	/// Данные, используемые в <see cref="ViewModels.ChangeWorkWindowViewModel"/>
	/// </summary>
	public class ChangeWorkWindowData
	{
		/// <summary>
		/// Работа, которую необходимо поменять.
		/// </summary>
		public Work WorkToChange { get; set; }
		/// <summary>
		/// Создает экземпляр данных <see cref="ChangeWorkWindowData"/> для <see cref="ViewModels.ChangeWorkWindowViewModel"/>
		/// с работой для изменения <paramref name="workToChange"/>.
		/// </summary>
		/// <param name="workToChange">Работа для изменения</param>
		public ChangeWorkWindowData(Work workToChange)
		{
			WorkToChange = workToChange;
		}
	}
}
