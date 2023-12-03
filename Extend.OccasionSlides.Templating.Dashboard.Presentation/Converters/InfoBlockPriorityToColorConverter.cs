namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Converters
{
    public class InfoBlockPriorityToColorConverter : Xamarin.Forms.IValueConverter
    {
        public Xamarin.Forms.Color DefaultColor { get; set; }

        public Xamarin.Forms.Color AlternativeColor { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var priority = (int)value;

            return priority % 2 == 0 ? DefaultColor : AlternativeColor;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
