namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredTraslucentIntroOverImagePlacardViewWidthToContentBoxPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.CenteredTraslucentIntroOverImagePlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return new Xamarin.Forms.Thickness();

            var width = (double)value;

            if (width <= 0) return new Xamarin.Forms.Thickness();

            var concreteBindingContext = PlacardView.BindingContext as Models.View.CenteredTraslucentIntroOverImagePlacardViewModel;

            var avaragePlacardSize = (width + PlacardView.Height) / 2d;

            switch (concreteBindingContext.ContentBoxPresentationKind)
            {
                case Enumerations.CenteredContentBoxPresentationKind.FloatBoxFilled:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.1d);

                case Enumerations.CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.2d, avaragePlacardSize * 0.05d);

                case Enumerations.CenteredContentBoxPresentationKind.FloatBandVertical:
                    return new Xamarin.Forms.Thickness(avaragePlacardSize * 0.1d, avaragePlacardSize * 0.2d);

                case Enumerations.CenteredContentBoxPresentationKind.Inmersive:
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
