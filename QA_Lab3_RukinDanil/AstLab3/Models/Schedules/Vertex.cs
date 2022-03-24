using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AstLab3.Models.Schedules
{
	/// <summary>
	/// Событие сетевого графика.
	/// </summary>
	public class Vertex : IEquatable<Vertex>
	{
		/// <summary>
		/// Уникальный идентификатор события.
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Ранний срок сверешния события.
		/// </summary>
		public int EarlyCompletionDate { get; set; } = 0;
		/// <summary>
		/// Поздний срок сверешения события
		/// </summary>
		public int LateCompletionDate { get; set; } = int.MaxValue;
		/// <summary>
		/// Полный резерв времени
		/// </summary>
		public int ReserveTime => LateCompletionDate - EarlyCompletionDate;
		/// <summary>
		/// Создает новый объект события <see cref="Vertex"/> с указанным <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Уникальный идентификатор события</param>
		public Vertex(int id)
		{
			ID = id;
		}
		/// <summary>
		/// Создает полную копию текущего объекта. Клон является независмой сущностью в памяти.
		/// </summary>
		/// <returns>Полная копия текущего объекта</returns>
		internal Vertex Clone()
		{
			Vertex result = new Vertex(ID);
			result.EarlyCompletionDate = EarlyCompletionDate;
			result.LateCompletionDate = LateCompletionDate;
			return result;
		}
		/// <summary>
		/// Указывает, являтеся ли объект <paramref name="obj"/> эквивалентным текущему.
		/// </summary>
		/// <param name="obj">Объект для сравнения</param>
		/// <returns><see langword="true"/>, если объекты идентичны, иначе <see langword="false"/>.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Vertex vertex = obj as Vertex;
			return Equals(vertex);
		}

		public static bool operator ==(Vertex left, Vertex right)
		{
			if (((object)left) == null || ((object)right) == null)
				return Object.Equals(left, right);

			return left.Equals(right);
		}

		public static bool operator !=(Vertex left, Vertex right)
		{
			if (((object)left) == null || ((object)right) == null)
				return !Object.Equals(left, right);

			return !(left.Equals(right));
		}

		/// <summary>
		/// Возвращает <see cref="ID"/>  данного объекта
		/// </summary>
		/// <returns>Возвращает <see cref="ID"/>  данного объекта</returns>
		public override int GetHashCode() => ID;


		/// <returns>Возвращает <see cref="ID"/>  данного объекта в виде строки</returns>
		/// <inheritdoc/>
		public override string ToString() => ID.ToString();
		/// <summary>
		/// Указывает, являтеся ли объект <paramref name="other"/> эквивалентным текущему, путем сравнения <see cref="ID"/> объектов.
		/// </summary>
		/// <param name="other">Объект событие сетевого графика для сравления</param>
		/// <returns></returns>
		public bool Equals([AllowNull] Vertex other)
		{
			if (other == null)
				return false;
			return ID == other.ID;
		}

		public static bool operator <(Vertex left, Vertex right) => left.ID < right.ID;

		public static bool operator >(Vertex left, Vertex right) => left.ID > right.ID;

		public static bool operator <=(Vertex left, Vertex right) => left.ID <= right.ID;

		public static bool operator >=(Vertex left, Vertex right) => left.ID >= right.ID;
	}
}
