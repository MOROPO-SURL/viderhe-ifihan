namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class PlacardViewModelToOverviewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            return Providers.PlacardOverviewProvider.GetPlacardOverview(value as Support.Presentation.Models.View.PlacardViewModel, Providers.CloudServerProvider.Instance);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
