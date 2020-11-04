namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Converters
{
    public class TemplateViewModelToTemplateThumbnailWrapViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            var model = value as Support.Presentation.Models.View.TemplateViewModel;

            if (model.PlayerOrientationSupport != Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait)
            {
                return new Views.LandscapeTemplateThumbnailWrapView(model);
            }
            else
            {
                return new Views.PortraitTemplateThumbnailWrapView(model);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
