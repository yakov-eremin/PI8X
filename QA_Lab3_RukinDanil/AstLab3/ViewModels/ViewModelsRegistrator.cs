using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Статический класс, предназначенный для создания методов расширения <see cref="IServiceCollection"/>
	/// </summary>
	public static class ViewModelsRegistrator
	{
		/// <summary>
		/// Метод регистрации моделей представления в DI контейнере.
		/// </summary>
		/// <param name="services">Коллекция сервисов <see cref="IServiceCollection"/></param>
		/// <returns>Коллекция сервисов <see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddViewModels(this IServiceCollection services) => services
		   .AddSingleton<MainWindowViewModel>()
		;
	}
}
