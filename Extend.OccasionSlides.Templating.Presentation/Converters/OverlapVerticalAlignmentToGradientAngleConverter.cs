using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class OverlapVerticalAlignmentToGradientAngleConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (OverlapAlignment)value == OverlapAlignment.Start ? 0 : 180;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
