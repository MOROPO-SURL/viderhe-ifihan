using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredContentBoxPresentationKindToColumIndexConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((CenteredContentBoxPresentationKind)value)
            {
                case CenteredContentBoxPresentationKind.Inmersive:
                case CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return 0;

                case CenteredContentBoxPresentationKind.FloatBandVertical:
                case CenteredContentBoxPresentationKind.FloatBoxFilled:
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
