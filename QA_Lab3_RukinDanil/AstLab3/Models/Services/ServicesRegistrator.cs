using AstLab3.Models.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services
{
	/// <summary>
	/// Статический класс для регистрации сервисов в DI контейнере.
	/// </summary>
	public static class ServicesRegistrator
	{
		/// <summary>
		/// Метод расширения. Регистрирует сервисы в коллекции сервисов <see cref="IServiceCollection"/>
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddServices(this IServiceCollection services) => services
			.AddSingleton<ILogger, LoggerService>()
		// Register your services here
		;
	}
}
