using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace softaware.Xaml.Converters
{
    [ContentProperty("Converters")]
    public class ConverterChain : Converter, IMultiValueConverter
    {
        public ConverterChain()
        {
            this.Converters = new List<IValueConverter>();
        }

        public IMultiValueConverter MultiConverter { get; set; }

        public List<IValueConverter> Converters { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in this.Converters)
            {
                value = converter.Convert(value, targetType, parameter, culture);
            }

            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var converter in this.Converters.AsEnumerable().Reverse())
            {
                value = converter.ConvertBack(value, targetType, parameter, culture);
            }

            return value;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.MultiConverter != null)
            {
                return this.Convert(this.MultiConverter.Convert(values, targetType, parameter, culture), targetType, parameter, culture);
            }

            throw new NotSupportedException("The MultiConverter property must be set to use this method.");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (this.MultiConverter != null)
            {
                value = this.ConvertBack(value, typeof(object), parameter, culture);
                return this.MultiConverter.ConvertBack(value, targetTypes, parameter, culture);
            }

            throw new NotSupportedException("The MultiConverter property must be set to use this method.");
        }
    }
}
