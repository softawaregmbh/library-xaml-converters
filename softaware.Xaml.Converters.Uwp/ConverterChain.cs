using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace softaware.Xaml.Converters
{
    [ContentProperty(Name="Converters")]
    public class ConverterChain : Converter
    {
        public ConverterChain()
        {
            this.Converters = new List<IValueConverter>();
        }

        public List<IValueConverter> Converters { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in this.Converters)
            {
                value = converter.Convert(value, targetType, parameter, culture.ToString());
            }

            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in this.Converters.AsEnumerable().Reverse())
            {
                value = converter.ConvertBack(value, targetType, parameter, culture.ToString());
            }

            return value;
        }
    }
}
