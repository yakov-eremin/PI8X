using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;

namespace AstLab3.ViewModels.Base
{
	/// <summary>
	/// Базовый класс модели представления. 
	/// Реализует базовую функциоанальность модели представления для осуществления работы паттерна MVVM.
	/// </summary>
	/// <remarks>
	/// Является расширением разметки, поэтому объекты <see cref="ViewModel"/> можно использовать в xaml разметке.<br/>
	/// Базово реализует интерфейс <see cref="INotifyPropertyChanged"/>. Реализацию не следует переопределять.
	/// </remarks>
	public class ViewModel : MarkupExtension, INotifyPropertyChanged
	{
		/// <summary>
		/// Происходит, когда какое-либо свойство <see cref="ViewModel"/> изменяется.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Возвращает объект, предоставленный в качестве значения целевого свойства<br/>
		/// для этого расширения разметки.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider) => this;

		protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		/// <summary>
		/// Метод занимается установкой измененного значения свойств. Предотвращает возможные зацикливания при изменении свойства.
		/// </summary>
		/// <remarks>
		/// Его следует вызывать при реализации <see langword="set"/> аксессора для установки значения<br/>
		/// свойства и предотвращения зацикливания.
		/// </remarks>
		/// <typeparam name="T">Тип поля, доступ к которому предоставляет свойство</typeparam>
		/// <param name="field">Ссылка (настоящая) на поле, доступ к которому предоставляет свойство.</param>
		/// <param name="value">Ссылка на значение, которе следует присвоить свойству</param>
		/// <param name="PropertyName">Имя свойства, которое изменилось</param>
		/// <returns></returns>
		protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
		{
			if (Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(PropertyName);
			return true;
		}
	}
}
