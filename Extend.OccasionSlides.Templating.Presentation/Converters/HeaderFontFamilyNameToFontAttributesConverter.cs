namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class HeaderFontFamilyNameToFontAttributesConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? Xamarin.Forms.FontAttributes.None : Xamarin.Forms.FontAttributes.Bold | Xamarin.Forms.FontAttributes.Italic;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
