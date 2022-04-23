namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredContentBoxPresentationKindToColumIndexConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Enumerations.CenteredContentBoxPresentationKind)value)
            {
                case Enumerations.CenteredContentBoxPresentationKind.Inmersive:
                case Enumerations.CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return 0;

                case Enumerations.CenteredContentBoxPresentationKind.FloatBandVertical:
                case Enumerations.CenteredContentBoxPresentationKind.FloatBoxFilled:
                default:
                    return 1;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
