namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class IsPlayerConnectedToViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isConnected = value != null && value is bool && (bool)value;

            if (isConnected)
            {
                return new Support.Presentation.Views.IdentityBackgroundView();
            }
            else
            {
                return new Xamarin.Forms.BoxView
                {
                    BackgroundColor = Xamarin.Forms.Color.Black
                };
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}