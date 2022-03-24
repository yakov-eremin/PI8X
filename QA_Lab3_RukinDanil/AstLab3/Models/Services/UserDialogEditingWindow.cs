using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Interfaces;
using AstLab3.ViewModels;
using AstLab3.Views.Windows;
using AstLab3.Models.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services
{
	/// <summary>
	/// Диалоговое окно для редактирования сетевого графика.
	/// </summary>
	public class UserDialogEditingWindow : IUserDialog<NetworkSchedule>
	{
		private ILogger _logger;
		private EditingWindowData _editingWindowData;
		/// <inheritdoc/>
		public bool Edit(NetworkSchedule toEdit)
		{
			EditWindow editWindow = new EditWindow();
			EditWindowViewModel editWindowViewModel = new EditWindowViewModel(_editingWindowData ,toEdit, _logger);
			editWindow.DataContext = editWindowViewModel;
			editWindow.Owner = App.Current.MainWindow;
			editWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
			editWindowViewModel.CloseWindow += (_, e) =>
			{
				editWindow.DialogResult = e.DialogResult;
				editWindow.Close();
			};
			return editWindow.ShowDialog() ?? false;
		}
		/// <summary>
		/// Создает диалоговое окно <see cref="UserDialogEditingWindow"/> с данными для редактирования <see cref="Data.EditingWindowData"/>
		/// и логгером.
		/// </summary>
		/// <param name="editingWindowData">Данные, необходимые для редактирования сетевого графика.</param>
		/// <param name="logger">Логгер для регистрации процесса редактирования сетевого графика.</param>
		public UserDialogEditingWindow(EditingWindowData editingWindowData, ILogger logger)
		{
			_editingWindowData = editingWindowData;
			_logger = logger;
		}
	}
}
