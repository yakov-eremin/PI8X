using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Репозиторий моделей представления. Предназначен для извлечения моделей и привязки к xaml разметке,
	/// но можно использовать и в коде C# для получения моделей как сервисов.
	/// </summary>
	public class ViewModelLocator
	{
		/// <summary>
		/// Возвращает из DI контейнера модель представления <see cref="MainWindowViewModel"/> главного окна.
		/// </summary>
		public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
	}
}
