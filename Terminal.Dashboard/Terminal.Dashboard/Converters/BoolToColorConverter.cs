namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class BoolToColorConverter : Xamarin.Forms.IValueConverter
    {
        [Xamarin.Forms.TypeConverter(typeof(Xamarin.Forms.ColorTypeConverter))]
        public Xamarin.Forms.Color TrueColor { get; set; }

        [Xamarin.Forms.TypeConverter(typeof(Xamarin.Forms.ColorTypeConverter))]
        public Xamarin.Forms.Color FalseColor { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var castedValue = (bool)value;

            return castedValue ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
