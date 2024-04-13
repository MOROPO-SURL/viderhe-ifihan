using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    internal class OverlapSizeToGradientStopOffsetConverter : Xamarin.Forms.IValueConverter
    {
        public bool IsForContent { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var columns = ((OverlapSize)value).ToColumnCount();

            return MagicGradients.Offset.Prop((columns - 1d) / 6d * 0.85d);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
