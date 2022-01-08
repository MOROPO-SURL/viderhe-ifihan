namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class FlyoutWidthToInfoBlockPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var wrapperWidth = (double)value;

            if (wrapperWidth == -1) return null;

            var padding = wrapperWidth / (Providers.ConstantProvider.CONTEXT_OVERLAY_FLYOUT_PADDING_BY_WRAPPER_WIDTH_RAZON * 2);

            return new Xamarin.Forms.Thickness(0, padding, 0, 0);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
