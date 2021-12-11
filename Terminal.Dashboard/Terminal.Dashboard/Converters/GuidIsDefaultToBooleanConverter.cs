namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class GuidIsDefaultToBooleanConverter : Xamarin.Forms.IValueConverter
    {
        public bool Denied { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var target = (System.Guid)value;

            var result = target == default;

            if (Denied) return !result;

            return result;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
