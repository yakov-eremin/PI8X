using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AstLab3.Models.Schedules
{
	/// <summary>
	/// Работа сетевого графика. <img src="D:\cloned_repos\PI8X\QA_Lab3_RukinDanil\user_icon.png" width="75" height="75" />
	/// </summary>
	public class Work : IEquatable<Work>
	{
		/// <summary>
		/// Начальное событие работы.
		/// </summary>
		public Vertex StartVertex { get; set; }
		/// <summary>
		/// Конечное событие работы
		/// </summary>
		public Vertex EndVertex { get; set; }
		/// <summary>
		/// Продолжительность работы
		/// </summary>
		public int Length { get; set; }
		/// <summary>
		/// Ранний срок начала работы
		/// </summary>
		public int EarlyStartDate => StartVertex.EarlyCompletionDate;
		/// <summary>
		/// Поздний срок начала работы
		/// </summary>
		public int LateStartDate => EndVertex.LateCompletionDate - Length;
		/// <summary>
		/// Ранний срок окончания работы
		/// </summary>
		public int EarlyEndDate => StartVertex.EarlyCompletionDate + Length;
		/// <summary>
		/// Поздний срок окончания работы
		/// </summary>
		public int LateEndDate => EndVertex.LateCompletionDate;
		/// <summary>
		/// Полный резерв времени работы
		/// </summary>
		/// <remarks>
		/// Полный резерв времени работы вычисляется по формуле \f$x_l - y_e - length\f$,
		/// где \f$x_l\f$ - поздний срок сверешния конечного события,
		/// \f$y_e\f$ - ранний срок сверешния начального события,
		/// \f$length\f$ - продолжительность работы.
		/// </remarks>
		public int FullTimeReserve => EndVertex.LateCompletionDate - StartVertex.EarlyCompletionDate - Length;
		/// <summary>
		/// Частный резерв времени работы
		/// </summary>
		public int PrivateTimeReserve { get; set; }
		/// <summary>
		/// Свободный резерв времени работы
		/// </summary>
		public int FreeTimeReserve { get; set; }
		/// <summary>
		/// Независимый резерв времени работы
		/// </summary>
		public int IndependentTimeReserve => EndVertex.EarlyCompletionDate - StartVertex.LateCompletionDate - Length;
		/// <summary>
		/// Создает экземпляр работы сетевого графика <see cref="Work"/> с указанной начальным, конечным событиями и продолжительностью.
		/// </summary>
		/// <param name="startVertex">Начальное событие</param>
		/// <param name="endVertex">Конечное событие</param>
		/// <param name="length">Продолжительность</param>
		public Work(Vertex startVertex, Vertex endVertex, int length)
		{
			StartVertex = startVertex;
			EndVertex = endVertex;
			Length = length;
		}

		public override string ToString() => $"{StartVertex.ID} → {EndVertex.ID} = {Length}";
		/// <summary>
		/// Создает полную копию текущей работы. Созданный клон является назависимым объектом.
		/// </summary>
		/// <returns>Полная копия текущей работы</returns>
		internal Work Clone()
		{
			Work result = new Work(StartVertex.Clone(), EndVertex.Clone(), Length);
			result.PrivateTimeReserve = PrivateTimeReserve;
			result.FreeTimeReserve = FreeTimeReserve;
			return result;
		}
		/// <summary>
		/// Сравнивает текущий объект работы с <paramref name="other"/>
		/// </summary>
		/// <param name="other">Объект для сравнения</param>
		/// <returns>Вернет <see langword="true"/>, если начальное и конечное события, а также продолжительность обоих объектов равны,
		/// иначе <see langword="false"/></returns>
		public bool Equals([AllowNull] Work other)
		{
			if (other == null)
				return false;
			return other.StartVertex == StartVertex
				&& other.EndVertex == EndVertex
				&& other.Length == Length;
		}
		/// <summary>
		/// Сравнивает текущий объект работы с <paramref name="other"/>
		/// </summary>
		/// <param name="obj">Объект для сравнения</param>
		/// <returns>Вернет <see langword="true"/>, если начальное и конечное события, а также продолжительность обоих объектов равны,
		/// иначе <see langword="false"/></returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Work work = obj as Work;
			return Equals(work);
		}

		public override int GetHashCode() => base.GetHashCode();

		public static bool operator ==(Work left, Work right)
		{
			if (((object)left) == null || ((object)right) == null)
				return Object.Equals(left, right);

			return left.Equals(right);
		}

		public static bool operator !=(Work left, Work right)
		{
			if (((object)left) == null || ((object)right) == null)
				return !Object.Equals(left, right);

			return !(left.Equals(right));
		}
		/// <summary>
		/// Возвращает строковое представление работы. Свойство предназначено для использования в xaml разметке.
		/// </summary>
		public string Self => ToString();
	}
}
