namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class FlyoutWidthToRightContentPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var wrapperWidth = (double)value;

            if (wrapperWidth == -1) return null;

            var padding = wrapperWidth / Providers.ConstantProvider.CONTEXT_OVERLAY_FLYOUT_PADDING_BY_WRAPPER_WIDTH_RAZON;

            return new Xamarin.Forms.Thickness(padding * 0.20, padding, padding * 0.80, padding);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
