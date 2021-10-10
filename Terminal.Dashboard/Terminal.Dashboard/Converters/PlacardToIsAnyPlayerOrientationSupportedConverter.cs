namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class PlacardToIsAnyPlayerOrientationSupportedConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return false;

            var target = value as Support.Presentation.Models.View.PlacardViewModel;

            if (target.PlayerOrientationSupportKind != null)
            {
                return target.PlayerOrientationSupportKind == Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
            }

            return target.Template.PlayerOrientationSupport == Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
