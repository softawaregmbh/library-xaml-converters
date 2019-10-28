using System;
using System.Collections;
using System.Globalization;

namespace softaware.Xaml.Converters
{
    public class EmptyConverter : Converter
    {
        public EmptyConverter()
        {
            this.TreatNullAsEmpty = true;
        }

        public bool TreatNullAsEmpty { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return this.TreatNullAsEmpty;
            }

            var enumerable = (IEnumerable)value;
            var enumerator = enumerable.GetEnumerator();
            return !enumerator.MoveNext();
        }
    }
}
