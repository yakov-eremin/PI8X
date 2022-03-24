using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Services.Interfaces
{
	/// <summary>
	/// Предоставляет диалоговое окно для общения с пользователем
	/// </summary>
	/// <typeparam name="T">Сущность для редактирования в окне.</typeparam>
	public interface IUserDialog<T>
	{
		/// <summary>
		/// Редактирует сущность <typeparamref name="T"/>
		/// </summary>
		/// <param name="toEdit">Сущность для редактирования</param>
		/// <returns></returns>
		bool Edit(T toEdit);
	}
}
