using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BindingDemo
{
	public class NumberToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string str = value.ToString();
			if (str == "42")
			{
				return new SolidColorBrush(Colors.BurlyWood);
			}
			return new SolidColorBrush(Colors.HotPink);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}