using System;
using System.Globalization;

namespace softaware.Xaml.Converters
{
    public class StringFormatConverter : Converter
    {
        public bool FormatEmptyStrings { get; set; }

        public StringFormatConverter()
        {
            this.FormatEmptyStrings = true;
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format = parameter as string;
            if (value == null || format == null)
            {
                return value;
            }

            if (value.Equals(string.Empty) && !this.FormatEmptyStrings)
            {
                return value;
            }

            if (format.StartsWith("{}"))
            {
                format = format.Substring(2);
            }

            return string.Format(culture, format, value);
        }
    }
}
