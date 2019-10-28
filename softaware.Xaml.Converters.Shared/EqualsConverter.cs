using System;
using System.Globalization;

#if WINDOWS_UWP
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace softaware.Xaml.Converters
{
    public class EqualsConverter : Converter
#if !WINDOWS_UWP
#pragma warning disable SA1001 // Commas should be spaced correctly
        , IMultiValueConverter
#pragma warning restore SA1001 // Commas should be spaced correctly
#endif
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals(value, parameter);
        }

        #if !WINDOWS_UWP
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals(values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endif
    }
}
