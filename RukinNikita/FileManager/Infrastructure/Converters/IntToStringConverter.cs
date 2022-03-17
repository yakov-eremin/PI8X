﻿using FileManager.Infrastructure.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FileManager.Infrastructure.Converters
{
	class IntToStringConverter : Converter
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString();
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!int.TryParse((string)value, out int num) || num < 0)
				return 0;
			else
				return num;
		}
	}
}
