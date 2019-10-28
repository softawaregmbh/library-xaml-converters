using System;
using System.Collections;
using System.Globalization;
using System.Linq;

#if WINDOWS_UWP
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace softaware.Xaml.Converters
{
    public class ContainsConverter : Converter
#if !WINDOWS_UWP
#pragma warning disable SA1001 // Commas should be spaced correctly
    , IMultiValueConverter
#pragma warning restore SA1001 // Commas should be spaced correctly
#endif
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = (IEnumerable)value;
            return enumerable.OfType<object>().Any(o => object.Equals(o, parameter));
        }

        #if !WINDOWS_UWP
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(values[0], targetType, values[1], culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endif
    }
}
