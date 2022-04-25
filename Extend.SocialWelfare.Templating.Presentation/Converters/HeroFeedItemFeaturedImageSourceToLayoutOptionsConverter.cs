namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Converters
{
    public class HeroFeedItemFeaturedImageSourceToLayoutOptionsConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Xamarin.Forms.LayoutOptions.Fill : Xamarin.Forms.LayoutOptions.End;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
