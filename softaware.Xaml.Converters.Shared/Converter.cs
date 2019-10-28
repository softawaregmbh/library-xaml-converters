using System;
using System.Globalization;
#if WINDOWS_UWP
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace softaware.Xaml.Converters
{
    public abstract class Converter : IValueConverter
    {
    #if WINDOWS_UWP

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return this.Convert(value, targetType, parameter, new CultureInfo(language));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.ConvertBack(value, targetType, parameter, new CultureInfo(language));
        }

        #endif

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
