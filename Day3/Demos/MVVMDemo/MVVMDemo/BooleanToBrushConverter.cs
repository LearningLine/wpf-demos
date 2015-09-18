using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMDemo
{
	public class BooleanToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				bool terminated;
				bool parsed = bool.TryParse(value.ToString(), out terminated);

				if (parsed && terminated)
				{
					return new SolidColorBrush(Colors.Red);
				}
			}
			return Binding.DoNothing;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}