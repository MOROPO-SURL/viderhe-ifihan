namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class SizingModeToHeightConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            if (!(value is Enumerations.SeparatorSizingMode)) return value;

            return (double)Xamarin.Forms.StackLayout.SpacingProperty.DefaultValue * ((int)(Enumerations.SeparatorSizingMode)value + 1);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
