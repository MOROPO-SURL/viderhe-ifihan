namespace SmartSolucionesCuba.Videre.Support.Presentation.Converters
{
    public class DateTimeRelativeConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var datetime = (System.DateTime)value;

            return string.Format("{0}, {1}", datetime.ToString("dddd, MMMM dd"), datetime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
