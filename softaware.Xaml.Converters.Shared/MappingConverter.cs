using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#if WINDOWS_UWP
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Markup;
#endif

namespace softaware.Xaml.Converters
{
    #if WINDOWS_UWP
    [ContentProperty(Name="Mappings")]
    #else
    [ContentProperty("Mappings")]
    #endif
    public class MappingConverter : Converter
    {
        public List<Mapping> Mappings { get; set; }

        public MappingConverter()
        {
            this.Mappings = new List<Mapping>();
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mapping = this.Mappings.FirstOrDefault(m => object.Equals(value, m.From));
            return mapping == null ? value : mapping.To;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mapping = this.Mappings.FirstOrDefault(m => object.Equals(value, m.To));
            return mapping == null ? value : mapping.From;
        }
    }
}
