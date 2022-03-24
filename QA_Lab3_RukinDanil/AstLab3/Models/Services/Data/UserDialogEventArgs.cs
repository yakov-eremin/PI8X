using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Data
{
	/// <summary>
	/// Арлгументы события <see cref="ViewModels.ClosableViewModel.CloseWindow"/>.
	/// </summary>
	public class UserDialogEventArgs : EventArgs
	{
		/// <summary>
		/// Создает экземпляр аргументов события <see cref="ViewModels.ClosableViewModel.CloseWindow"/> 
		/// с результатом диалога с пользователем.
		/// </summary>
		/// <param name="result">Результат диалога с пользователем</param>
		public UserDialogEventArgs(bool? result)
		{
			DialogResult = result;
		}
		/// <summary>
		/// Результат работы пользователя и диалогового окна.
		/// </summary>
		/// <value><see langword="true"/>, если пользователь выполнил необходимые задачи, иначе <see langword="false"/></value>
		public bool? DialogResult { get; set; } = false;
	}
}
