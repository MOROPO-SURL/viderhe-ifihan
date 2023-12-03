using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Providers;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class OverlapWidthToInfoBlockPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var wrapperWidth = (double)value;

            if (wrapperWidth == -1) return new Xamarin.Forms.Thickness();

            var padding = wrapperWidth / (ConstantProvider.CONTEXTUAL_OVERLAP_PADDING_BY_WRAPPER_WIDTH_RAZON * 2);

            return new Xamarin.Forms.Thickness(0, padding, 0, 0);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
