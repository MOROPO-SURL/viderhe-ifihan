namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Converters
{
    public class LandscapePresentationSideToLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var landscapePresentationSide = (Enumerations.LandscapePresentationSide)value;

            return landscapePresentationSide == Enumerations.LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
