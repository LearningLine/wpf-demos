using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Explorer
{
    class DateToBrushConverter : IValueConverter
    {
        private Brush oldBrush;
        private Brush newBrush;

        public Brush OldBrush
        {
            get { return oldBrush; }
            set { oldBrush = value; }
        }

        public Brush NewBrush
        {
            get { return newBrush; }
            set { newBrush = value; }
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = System.Convert.ToDateTime(value);
            return (dt.Date == DateTime.Now.Date) ? NewBrush : OldBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
