namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Converters
{
    public class IsNullToStringConverter : Xamarin.Forms.IValueConverter
    {
        public object CaseTrue { get; set; }

        public object CaseFalse { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? CaseTrue : CaseFalse;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
