using System;
using System.Collections.Generic;
using System.Text;
using AstLab3.Models.Services.Data;
using AstLab3.ViewModels.Base;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Модель представления окна, которое можно закрыть.
	/// </summary>
	/// <inheritdoc cref="ViewModel"/>
	public class ClosableViewModel : ViewModel
	{
		/// <summary>
		/// Происходит, когда пользователь вызывает команду <see cref="Infrastructure.Commands.CloseWindowCommand"/> или
		/// пытается закрыть окно любым другим способом.
		/// </summary>
		public event EventHandler<UserDialogEventArgs> CloseWindow;

		protected virtual void OnCloseWindow(UserDialogEventArgs e) => CloseWindow?.Invoke(this, e);
	}
}
