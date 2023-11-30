using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Converters
{
    public class TemplateViewModelToTemplateThumbnailWrapViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            var model = value as TemplateViewModel;

            if (model.PlayerOrientationSupport != PlayerOrientationSupportKind.Portrait)
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
