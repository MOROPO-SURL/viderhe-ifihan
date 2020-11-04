namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class PlacardViewModelToPlacardThumbnailWrapViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            var model = value as Support.Presentation.Models.View.PlacardViewModel;

            if (model.Template.PlayerOrientationSupport != Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait)
            {
                return new Views.LandscapePlacardThumbnailWrapView(model);
            }
            else
            {
                return new Views.PortraitPlacardThumbnailWrapView(model);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
