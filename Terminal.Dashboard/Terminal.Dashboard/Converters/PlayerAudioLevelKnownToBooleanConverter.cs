namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class PlayerAudioLevelKnownToBooleanConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var audioLebel = (int)value;

            return audioLebel >= 0;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
