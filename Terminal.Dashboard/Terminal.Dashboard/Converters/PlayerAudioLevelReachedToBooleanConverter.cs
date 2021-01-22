namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class PlayerAudioLevelReachedToBooleanConverter : Xamarin.Forms.IValueConverter
    {
        public int TargetAudioLevel { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var audioLevel = (int)value;

            if (audioLevel < 0) return false;

            return audioLevel != TargetAudioLevel;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
