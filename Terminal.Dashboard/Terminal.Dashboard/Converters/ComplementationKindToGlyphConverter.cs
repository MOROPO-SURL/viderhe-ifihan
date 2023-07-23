namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class ComplementationKindToGlyphConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var target = (Cloud.Persistence.Enumerations.PlacardComplementationKind)value;

            switch (target)
            {
                case Cloud.Persistence.Enumerations.PlacardComplementationKind.Video:
                    return "\uFCF5";

                case Cloud.Persistence.Enumerations.PlacardComplementationKind.Sound:
                    return "\uF333";

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
