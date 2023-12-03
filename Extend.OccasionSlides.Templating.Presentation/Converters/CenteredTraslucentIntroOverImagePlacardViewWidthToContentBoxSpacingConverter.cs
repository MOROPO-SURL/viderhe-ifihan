namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class CenteredTraslucentIntroOverImagePlacardViewWidthToContentBoxSpacingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.Placard.CenteredTraslucentIntroOverImagePlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return new Xamarin.Forms.Thickness();

            var width = (double)value;

            if (width <= 0) return new Xamarin.Forms.Thickness();

            var avaragePlacardSize = (width + PlacardView.Height) / 2d;

            return avaragePlacardSize * 0.012d;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
