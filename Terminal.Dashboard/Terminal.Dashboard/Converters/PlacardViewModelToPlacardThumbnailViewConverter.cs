namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class PlacardViewModelToPlacardThumbnailViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            return Providers.PlacardThumbnailViewProvider.Instance.GetPlacardThumnailView(value as Support.Presentation.Models.View.PlacardViewModel, Support.Presentation.Managers.SessionMemoryManager.Instance);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
