﻿using AstLab3.Infrastructure.Commands;
using AstLab3.Models.Schedules;
using AstLab3.Models.Services.Data;
using AstLab3.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Модель представления окна <see cref="Views.Windows.ChangeWorkWindow"/>.
	/// </summary>
	/// <inheritdoc/>
	public class ChangeWorkWindowViewModel : ClosableViewModel
	{
		private ILogger _logger;
		private NetworkSchedule _networkSchedule;
		/// <summary>
		/// Текущая выбранная работа
		/// </summary>
		public Work SelectedWork { get; set; }

		private string _worksLength = "";
		/// <summary>
		/// Продолжительность работы
		/// </summary>
		public string WorksLength { get => _worksLength; set => Set(ref _worksLength, value); }
		/// <summary>
		/// Создает модель представления <see cref="ChangeWorkWindowViewModel"/> окна <see cref="Views.Windows.ChangeWorkWindow"/>
		/// для работы над сетевым графиком.
		/// </summary>
		/// <param name="data">Данные, необходимые для обработки сетевого графика</param>
		/// <param name="networkSchedule">Сетевой график</param>
		/// <param name="logger">Логгер для регистрации процесса редактирования сетевого графика</param>
		public ChangeWorkWindowViewModel(ChangeWorkWindowData data, NetworkSchedule networkSchedule, ILogger logger)
		{
			_logger = logger;
			_networkSchedule = networkSchedule;
			SelectedWork = data.WorkToChange;
			WorksLength = SelectedWork.Length.ToString();
			CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
			ApplyCommand = new LambdaCommand(OnApplyCommandExecuted, CanApplyCommandExecute);
			_logger.LogMessage("Инициализировано окно для редактирования выбранной работы.");
		}
		/// <summary>
		/// Команда закрывания окна пользователем.
		/// </summary>
		public ICommand CancelCommand { get; }
		private void OnCancelCommandExecuted(object p)
		{
			_logger.LogMessage("Отказ от изменений. Окно закрыто.");
			OnCloseWindow(new UserDialogEventArgs(false));
		}
		private bool CanCancelCommandExecute(object p) => true;
		/// <summary>
		/// Команда применения изменений к сетевому графику
		/// </summary>
		public ICommand ApplyCommand { get; }
		private void OnApplyCommandExecuted(object p)
		{
			try
			{
				int length = Convert.ToInt32(WorksLength);
				CheckLength(length);
				foreach (var item in _networkSchedule.Table)
				{
					if ((SelectedWork.StartVertex == item.StartVertex) && (SelectedWork.EndVertex == item.EndVertex))
					{
						_logger.LogMessage($"Длина работы изменена с {item.Length} на {length}");
						item.Length = length;
						break;
					}
				}
				_logger.LogMessage("Изменениния применены. Окно закрыто.");
				OnCloseWindow(new UserDialogEventArgs(true));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
		private bool CanApplyCommandExecute(object p) => true;

		private void CheckLength(int length)
		{
			if (length < 0)
				throw new Exception("Продолжительность работы не может быть меньше 0");
		}
	}
}
