﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace KantorLr1.Infrastructure.Converters.Base
{
	public abstract class Converter : MarkupExtension, IValueConverter
	{
		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Обратоное преобразование не поддерживается");
		}

		public override object ProvideValue(IServiceProvider serviceProvider) => this;

	}
}
