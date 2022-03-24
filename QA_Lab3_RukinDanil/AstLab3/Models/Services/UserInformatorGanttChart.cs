using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Interfaces;
using AstLab3.ViewModels;
using AstLab3.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services
{
	/// <summary>
	/// Окно для отображения графика Ганта сетевого графика.
	/// </summary>
	public class UserInformatorGanttChart : IUserInformator<NetworkSchedule>
	{
		private ILogger _logger;
		/// <summary>
		/// Создает окно <see cref="UserInformatorGanttChart"/> для отображения графика Ганта сетевого графика с логгером.
		/// </summary>
		/// <param name="logger">Логгер для регистрации процесса отображения графика Ганта</param>
		public UserInformatorGanttChart(ILogger logger)
		{
			_logger = logger;
		}
		/// <inheritdoc/>
		public void Show(NetworkSchedule instance)
		{
			var window = new UserInformatorGanttChartWindow();
			var data = new UserInformatorGanttChartWindowViewModel(_logger, instance);
			window.DataContext = data;
			data.CloseWindow += (_, e) =>
			{
				window.DialogResult = true;
				window.Close();
			};
			window.ShowDialog();
		}
	}
}
