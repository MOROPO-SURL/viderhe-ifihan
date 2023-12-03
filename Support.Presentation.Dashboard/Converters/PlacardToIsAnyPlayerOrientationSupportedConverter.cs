using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Converters
{
    public class PlacardToIsAnyPlayerOrientationSupportedConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return false;

            var target = value as PlacardViewModel;

            if (target.Template == null) return false;

            if (target.PlayerOrientationSupportKind != null)
            {
                return target.PlayerOrientationSupportKind == PlayerOrientationSupportKind.Any;
            }

            return target.Template.PlayerOrientationSupport == PlayerOrientationSupportKind.Any;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
