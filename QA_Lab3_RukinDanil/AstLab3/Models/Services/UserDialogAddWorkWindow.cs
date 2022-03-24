using AstLab3.ViewModels;
using AstLab3.Views.Windows;
using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Interfaces;

namespace AstLab3.Models.Services
{
	/// <summary>
	/// Диалоговое окно для добавления работы в сетевой график.
	/// </summary>
	public class UserDialogAddWorkWindow : IUserDialog<NetworkSchedule>
	{
		private ILogger _logger;
		/// <summary>
		/// Создает окно <see cref="UserDialogAddWorkWindow"/> для редактирования сетевого графика <see cref="NetworkSchedule"/>
		/// </summary>
		/// <param name="logger">Логгер для отслеживания процесса редактирования</param>
		public UserDialogAddWorkWindow(ILogger logger)
		{
			_logger = logger;
		}
		/// <inheritdoc/>
		public bool Edit(NetworkSchedule toEdit)
		{
			var window = new AddWorkWindow();
			var data = new AddWorkWindowViewModel(toEdit, _logger);
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
	}
}
