namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class OverlapVerticalAlignmentToLayoutOptionsConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Enumerations.OverlapVerticalAlignment)value == Enumerations.OverlapVerticalAlignment.Top ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
