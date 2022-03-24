﻿using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Data;
using AstLab3.Models.Services.Interfaces;
using AstLab3.ViewModels;
using AstLab3.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services
{
	/// <summary>
	/// Создает окно <see cref="UserDialogChangeWorkWindow"/> для изменения работ сетевого графика <see cref="NetworkSchedule"/>
	/// </summary>
	public class UserDialogChangeWorkWindow : IUserDialog<NetworkSchedule>
	{
		private ILogger _logger;
		private ChangeWorkWindowData _changeWorkWindowData;
		/// <inheritdoc/>
		public bool Edit(NetworkSchedule toEdit)
		{
			var window = new ChangeWorkWindow();
			var data = new ChangeWorkWindowViewModel(_changeWorkWindowData, toEdit, _logger);
			window.DataContext = data;
			window.Owner = App.Current.MainWindow;
			window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
			data.CloseWindow += (_, e) =>
			{
				window.DialogResult = e.DialogResult;
				window.Close();
			};
			return window.ShowDialog() ?? false;
		}
		/// <summary>
		/// Создает диалоговое окно <see cref="UserDialogChangeWorkWindow"/> с данными <see cref="Data.ChangeWorkWindowData"/> и логгером
		/// </summary>
		/// <param name="data">Данные для редактирования</param>
		/// <param name="logger">Логгер для регистрация процесса редактирования</param>
		public UserDialogChangeWorkWindow(ChangeWorkWindowData data, ILogger logger)
		{
			_changeWorkWindowData = data;
			_logger = logger;
		}
	}
}
