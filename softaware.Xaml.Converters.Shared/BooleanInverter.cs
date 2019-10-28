namespace softaware.Xaml.Converters
{
    public class BooleanInverter : BooleanConverter
    {
        public BooleanInverter()
        {
            this.TrueValue = false;
            this.FalseValue = true;
        }
    }
}
