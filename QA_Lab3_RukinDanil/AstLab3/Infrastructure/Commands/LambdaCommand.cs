using AstLab3.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Infrastructure.Commands
{
	/// <summary>
	/// Команда-оболочка над <see cref="Command"/>.
	/// </summary>
	/// <remarks>
	/// Команда призвана упростить создание новых команд. Можно создавать объекты команд и определять свои методы для исполнения методов<br/>
	/// <see cref="Command.Execute(object)"/> и <see cref="Command.CanExecute(object)(object)"/>.
	/// </remarks>
	/// <example>
	/// Создание пользовательской команды.
	/// <code>
	/// public SomeClassConstructor()
	/// {
	///		SomeCommand = new LambdaCommand(OnSomeCommandExecuted, CanSomeCommandExecute);
	/// }
	/// public ICommand SomeCommand { get; }
	/// private void OnSomeCommandExecuted(object param) => Console.WriteLine(nameof(SomeCommand));
	/// private bool CanSomeCommandExecute(object param) => true;
	/// </code>
	/// </example>
	public class LambdaCommand : Command
	{
		private readonly Action<object> _Execute;
		private readonly Func<object, bool> _CanExecute;

		/// <summary>
		/// Конструктор LambdaCommand
		/// </summary>
		/// <param name="Execute">Делегат для метода <see cref="Command.Execute(object)"/></param>
		/// <param name="CanExecute">Делегат для метода <see cref="Command.CanExecute(object)"/></param>
		public LambdaCommand(Action Execute, Func<bool> CanExecute = null)
			: this(
				Execute: p => Execute(),
				CanExecute: CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
		{

		}
		/// <summary>
		/// Конструктор LambdaCommand
		/// </summary>
		/// <param name="Execute">Делегат для метода <see cref="Command.Execute(object)"/></param>
		/// <param name="CanExecute">Делегат для метода <see cref="Command.CanExecute(object)"/></param>
		/// <exception cref="ArgumentNullException"></exception>
		public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
		{
			_Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
			_CanExecute = CanExecute;
		}

		protected override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

		protected override void Execute(object parameter) => _Execute(parameter);
	}
}
