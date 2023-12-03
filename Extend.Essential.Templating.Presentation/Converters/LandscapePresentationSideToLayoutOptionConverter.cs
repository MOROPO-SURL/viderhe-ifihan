namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Converters
{
    public class LandscapePresentationSideToLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var presentationSide = (Enumerations.LandscapePresentationSide)value;

            return presentationSide == Enumerations.LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
