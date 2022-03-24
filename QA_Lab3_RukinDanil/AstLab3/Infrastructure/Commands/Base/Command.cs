using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AstLab3.Infrastructure.Commands.Base
{
	/// <summary>
	/// Абстрактный класс команды.
	/// </summary>
	public abstract class Command : ICommand
	{
		/// <summary>
		/// Происходит, когда происходят изменения, влияющие на выполнение команды. 
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		private bool _Executable = true;

		/// <summary>
		/// Указывает, является ли данная команда исполняемой.
		/// </summary>
		public bool Executable
		{
			get => _Executable;
			set
			{
				if (_Executable == value) return;
				_Executable = value;
				CommandManager.InvalidateRequerySuggested();
			}
		}
		/// <summary>
		/// Определяет, можно ли выполнить команду, т.е. вызвать метод <see cref="Execute(object)"/>
		/// </summary>
		/// <param name="parameter">Данные, используемые командой. Если команде не нужны данные,
		/// то этот параметр может быть равен null.</param>
		/// <returns></returns>
		bool ICommand.CanExecute(object parameter) => _Executable && CanExecute(parameter);

		/// <summary>
		/// Определяет метод, который будет исполнен во время вызова команды.
		/// </summary>
		/// <param name="parameter">Данные, используемые командой. Если команде не нужны данные,
		/// то этот параметр может быть равен null.</param>
		void ICommand.Execute(object parameter)
		{
			if (CanExecute(parameter))
				Execute(parameter);
		}

		protected virtual bool CanExecute(object parameter) => true;

		protected abstract void Execute(object parameter);
	}
}
