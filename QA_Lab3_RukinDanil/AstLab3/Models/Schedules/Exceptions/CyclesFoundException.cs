using System;
using System.Collections.Generic;
using System.Text;

namespace AstLab3.Models.Schedules.Exceptions
{
	/// <summary>
	/// Представляет ошибку, которая происходит, когда в сетевом графике найден цикл.
	/// </summary>
	public class CyclesFoundException : Exception
	{
		/// <summary>
		/// Коллекция работ в цикле.
		/// </summary>
		/// <value>Список работ <see cref="Work"/></value>
		public List<Work> WorksInCycle { get; set; }
		/// <summary>
		/// Создает новую сущность типа <see cref="CyclesFoundException"/> с сообщением об ошибке и списком работ в цикле.
		/// </summary>
		/// <param name="message">Сообщение об ошибке</param>
		/// <param name="worksInCycle">Список работ в цикле</param>
		public CyclesFoundException(string message, List<Work> worksInCycle) : base(message)
		{
			WorksInCycle = worksInCycle;
		}
	}
}
