namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class IsAnyPlayerOrientationSupportKindToBooleanConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var kind = (Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind)value;

            return kind == Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
