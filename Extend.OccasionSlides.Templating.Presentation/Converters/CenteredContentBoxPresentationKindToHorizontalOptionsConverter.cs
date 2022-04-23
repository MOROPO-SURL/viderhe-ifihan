namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredContentBoxPresentationKindToHorizontalOptionsConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Enumerations.CenteredContentBoxPresentationKind)value)
            {
                case Enumerations.CenteredContentBoxPresentationKind.Inmersive:
                    return Xamarin.Forms.LayoutOptions.Fill;

                case Enumerations.CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return Xamarin.Forms.LayoutOptions.Fill;

                case Enumerations.CenteredContentBoxPresentationKind.FloatBandVertical:
                    return Xamarin.Forms.LayoutOptions.Center;

                case Enumerations.CenteredContentBoxPresentationKind.FloatBoxFilled:
                default:
                    return Xamarin.Forms.LayoutOptions.Center;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
