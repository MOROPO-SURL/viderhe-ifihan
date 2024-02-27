using MOROPO.VIDERHE.Support.Presentation.Dashboard.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Converters
{
    public class PlacardViewModelToPlacardThumbnailViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            return Xamarin.Forms.DependencyService.Get<IPlacardThumbnailViewProvisioningHelperFacade>().GetPlacardThumnailView(value as PlacardViewModel);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
