using System;
using System.Globalization;

namespace softaware.Xaml.Converters
{
    public class BooleanConverter : Converter
    {
        public object TrueValue { get; set; }
        
        public object FalseValue { get; set; }

        public bool Inverted { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var condition = value as bool? == true; 
            return condition ? (this.Inverted ? this.FalseValue : this.TrueValue) : (this.Inverted ? this.TrueValue : this.FalseValue);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals(value, this.TrueValue) ? (bool?)!this.Inverted : object.Equals(value, this.FalseValue) ? (bool?)this.Inverted : null;
        }
    }
}
