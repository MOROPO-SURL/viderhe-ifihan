using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredTraslucentIntroOverImagePlacardViewWidthToContentBoxPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.Placard.CenteredTraslucentIntroOverImagePlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return new Xamarin.Forms.Thickness();

            var width = (double)value;

            if (width <= 0) return new Xamarin.Forms.Thickness();

            var concreteBindingContext = PlacardView.BindingContext as CenteredTraslucentIntroOverImagePlacardViewModel;

            var avaragePlacardSize = (width + PlacardView.Height) / 2d;

            switch (concreteBindingContext.ContentBoxPresentationKind)
            {
                case CenteredContentBoxPresentationKind.FloatBoxFilled:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.1d);

                case CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.2d, avaragePlacardSize * 0.05d);

                case CenteredContentBoxPresentationKind.FloatBandVertical:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.1d, avaragePlacardSize * 0.2d);

                case CenteredContentBoxPresentationKind.Inmersive:
                default:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.1d);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
