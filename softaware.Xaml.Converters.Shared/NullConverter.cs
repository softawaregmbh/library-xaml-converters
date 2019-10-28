using System;

namespace softaware.Xaml.Converters
{
    public class NullConverter : Converter
    {
        public bool TreatEmptyStringAsNull { get; set; }

        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return true;
            }

            if (this.TreatEmptyStringAsNull && value as string == string.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
