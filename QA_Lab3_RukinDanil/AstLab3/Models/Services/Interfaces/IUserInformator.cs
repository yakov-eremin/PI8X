using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Interfaces
{
	/// <summary>
	/// Предоставляет окно для вывода инофрмации.
	/// </summary>
	/// <typeparam name="T">Сущность, которую следует отобразить.</typeparam>
	public interface IUserInformator<T>
	{
		/// <summary>
		/// Отображает сущность <typeparamref name="T"/>
		/// </summary>
		/// <param name="instance">Сущность для отображения</param>
		void Show(T instance);
	}
}
