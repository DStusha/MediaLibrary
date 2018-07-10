using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaLibrary
{
    public class ToSizeConverter: IValueConverter
    {
        public static ToSizeConverter Instance =
            new ToSizeConverter();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is Double) return (Double)value - 200;
            return null;
        }

        public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
