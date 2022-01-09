using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class OverlapSizeToRightColumnIndexConverter : Xamarin.Forms.IValueConverter
    {
        public bool IsForContent { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = 6 - ((Enumerations.OverlapSize)value).ToColumnCount();

            if (IsForContent) result += 1;

            return  result;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
