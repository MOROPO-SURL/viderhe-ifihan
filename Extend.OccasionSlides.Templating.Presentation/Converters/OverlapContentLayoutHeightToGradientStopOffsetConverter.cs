namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    internal class OverlapContentLayoutHeightToGradientStopOffsetConverter : Xamarin.Forms.IValueConverter
    {
        public Xamarin.Forms.ContentView PlacardRootView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var concreteValue = (double)value;

            return MagicGradients.Offset.Prop(concreteValue / PlacardRootView.Height * 0.65d);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
