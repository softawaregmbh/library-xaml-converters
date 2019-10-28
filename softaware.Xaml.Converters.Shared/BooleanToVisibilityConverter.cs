#if WINDOWS_UWP
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

namespace softaware.Xaml.Converters
{
    public class BooleanToVisibilityConverter : BooleanConverter
    {
        #if !WINDOWS_UWP
        public bool UseHidden
        {
            get 
            {
                return object.Equals(this.FalseValue, Visibility.Hidden); 
            }

            set
            {
                this.FalseValue = value ? Visibility.Hidden : Visibility.Collapsed;
            }
        }
        #endif

        public BooleanToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }
    }
}
