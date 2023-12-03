using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredContentBoxPresentationKindToVerticalOptionsConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((CenteredContentBoxPresentationKind)value)
            {
                case CenteredContentBoxPresentationKind.Inmersive:
                    return Xamarin.Forms.LayoutOptions.Fill;

                case CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return Xamarin.Forms.LayoutOptions.Center;

                case CenteredContentBoxPresentationKind.FloatBandVertical:
                    return Xamarin.Forms.LayoutOptions.Fill;

                case CenteredContentBoxPresentationKind.FloatBoxFilled:
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
