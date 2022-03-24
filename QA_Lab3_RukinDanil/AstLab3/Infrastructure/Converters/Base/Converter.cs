using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace AstLab3.Infrastructure.Converters.Base
{
	/// <summary>
	/// Базовый класс-конвертер. Релизует интерфейс <seealso cref="IValueConverter"/>. Абстрактный класс.
	/// </summary>
	public abstract class Converter : MarkupExtension, IValueConverter
	{
		/// <summary>
		/// Конвертирует свойство из <see cref="ViewModels.Base.ViewModel"/> к привязанному элементу в xaml разметке.
		/// </summary>
		/// <param name="value">Свойство (поле) из <see cref="ViewModels.Base.ViewModel"/></param>
		/// <param name="targetType">Тип, в который необходимо произвести конвертацию</param>
		/// <param name="parameter">Параметр для конвертации</param>
		/// <param name="culture">Информация о культуре</param>
		/// <returns></returns>
		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		/// <summary>
		/// Конвертирует значение, предоставляемое интерфейсом в объект из привязанной <see cref="ViewModels.Base.ViewModel"/>
		/// </summary>
		/// <param name="value">Значение, поступающее из интерфейса</param>
		/// <param name="targetType">Тип, в который необходимо произвести конвертацию</param>
		/// <param name="parameter">Параметр для конвертации</param>
		/// <param name="culture">Информация о культуре</param>
		/// <returns></returns>
		/// <exception cref="NotSupportedException"></exception>
		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException($"Обратное преобразование не поддерживается ({this.GetType()})");
		}
		/// <summary>
		/// Возвращает объект, предоставленный в качестве значения целевого свойства<br/>
		/// для этого расширения разметки.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
