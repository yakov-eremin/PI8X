using AstLab3.Infrastructure.Commands;
using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Data;
using AstLab3.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Модель представления окна <see cref="Views.Windows.DeleteUselessWorkWindow"/>
	/// </summary>
	/// <inheritdoc/>
	public class DeleteUselessWorkWindowViewModel : ClosableViewModel
	{
		private DeleteUselessWorkWindowData _deleteUselessWorkWindowData;
		private NetworkSchedule _networkSchedule;
		private ILogger _logger;
		/// <summary>
		/// Создает модель представления <see cref="DeleteUselessWorkWindowViewModel"/>. Нужен только для дизайнера
		/// </summary>
		public DeleteUselessWorkWindowViewModel()
		{

		}
		/// <summary>
		/// Создает модель представления <see cref="DeleteUselessWorkWindowViewModel"/> окна <see cref="Views.Windows.DeleteUselessWorkWindow"/>
		/// для удаления из сетевого графика ненужных работ.
		/// </summary>
		/// <param name="deleteUselessWorkWindowData">Данные, необходимые для удаления ненужных работ</param>
		/// <param name="toEidt">Сетевой график для редактирования</param>
		/// <param name="logger">Логгер для регистрации процесса редактирования сетевого графика.</param>
		public DeleteUselessWorkWindowViewModel(DeleteUselessWorkWindowData deleteUselessWorkWindowData, NetworkSchedule toEidt, ILogger logger)
		{
			_logger = logger;
			_networkSchedule = toEidt;
			_deleteUselessWorkWindowData = deleteUselessWorkWindowData;
			DeleteFirstWorkIsNecessary = true;
			FirstWorkToDelete = deleteUselessWorkWindowData.FirstWorkToDelete.Self;
			SecondWorkToDelete = deleteUselessWorkWindowData.SecondWorkToDelete.Self;
			SelectWorkToDeleteCommand = new LambdaCommand(OnSelectWorkToDeleteCommandExecuted, CanSelectWorkToDeleteCommandExecute);
			DeleteCommand = new LambdaCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
			CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
			_logger.LogMessage("Инициализировано окно для удаления частично повторяющихся работ");
		}
		private bool _deleteFirstWorkIsNecessary = false;
		/// <summary>
		/// Возвращает или задает необходимость удаления первой работы
		/// </summary>
		public bool DeleteFirstWorkIsNecessary { get => _deleteFirstWorkIsNecessary; set => Set(ref _deleteFirstWorkIsNecessary, value); }

		private bool _deleteSecondWorkIsNecessary = false;
		/// <summary>
		/// Возвращает или задает необходимость удаления второй работы
		/// </summary>
		public bool DeleteSecondWorkIsNecessary { get => _deleteSecondWorkIsNecessary; set => Set(ref _deleteSecondWorkIsNecessary, value); }

		private string _firstWorkToDelete = "";
		/// <summary>
		/// Возвращает или задает текст для отображения возле объекта пользовательского интерфейса, предоставляющего возможность выбора
		/// при удалении первой работы.
		/// </summary>
		public string FirstWorkToDelete { get => _firstWorkToDelete; set => Set(ref _firstWorkToDelete, value); }

		private string _secondWorkToDelete = "";
		/// <summary>
		/// Возвращает или задает текст для отображения возле объекта пользовательского интерфейса, предоставляющего возможность выбора
		/// при удалении второй работы.
		/// </summary>
		public string SecondWorkToDelete { get => _secondWorkToDelete; set => Set(ref _secondWorkToDelete, value); }
		/// <summary>
		/// Команда удаления выбранной работы
		/// </summary>
		public ICommand DeleteCommand { get; }
		private void OnDeleteCommandExecuted(object p)
		{
			bool? result;
			if (DeleteFirstWorkIsNecessary)
			{
				if (_networkSchedule.Table.Remove(_deleteUselessWorkWindowData.FirstWorkToDelete))
				{
					_logger.LogMessage($"Работа {_deleteUselessWorkWindowData.FirstWorkToDelete} успешно удалена");
					result = true;
				}
				else
				{
					_logger.LogMessage($"Не удалось удалить работу {_deleteUselessWorkWindowData.FirstWorkToDelete}");
					result = false;
				}
			}
			else
			{
				if (_networkSchedule.Table.Remove(_deleteUselessWorkWindowData.SecondWorkToDelete))
				{
					_logger.LogMessage($"Работа {_deleteUselessWorkWindowData.SecondWorkToDelete} успешно удалена");
					result = true;
				}
				else
				{
					_logger.LogMessage($"Не удалось удалить работу {_deleteUselessWorkWindowData.SecondWorkToDelete}");
					result = false;
				}
			}
			OnCloseWindow(new UserDialogEventArgs(result));
			_logger.LogMessage("Окно удаления частично повторяющихся работ закрыто.");
		}
		private bool CanDeleteCommandExecute(object p) => true;

		/// <summary>
		/// Команда закрывания окна
		/// </summary>
		public ICommand CancelCommand { get; }
		private void OnCancelCommandExecuted(object p)
		{
			_logger.LogMessage("Пользователь не удалил ни одну из частично повторяющихся работ. Окно закрыто.");
			OnCloseWindow(new UserDialogEventArgs(false));
		}
		private bool CanCancelCommandExecute(object p) => true;
		/// <summary>
		/// Команда выбора работы для удаления
		/// </summary>
		public ICommand SelectWorkToDeleteCommand { get; }
		private void OnSelectWorkToDeleteCommandExecuted(object p)
		{
			string param = (string)p;
			if (param == "first")
			{
				DeleteFirstWorkIsNecessary = true;
				DeleteSecondWorkIsNecessary = false;
				_logger.LogMessage($"Пользователь отметил работу {FirstWorkToDelete}");
			}
			else
			{
				DeleteSecondWorkIsNecessary = true;
				DeleteFirstWorkIsNecessary = false;
				_logger.LogMessage($"Пользователь отметил работу {SecondWorkToDelete}");
			}
		}

		private bool CanSelectWorkToDeleteCommandExecute(object p) => true;
	}
}
