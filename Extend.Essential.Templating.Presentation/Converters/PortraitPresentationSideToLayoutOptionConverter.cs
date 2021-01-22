namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Converters
{
    public class PortraitPresentationSideToLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var presentationSide = (Enumerations.PortraitPresentationSide)value;

            return presentationSide == Enumerations.PortraitPresentationSide.Top ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
