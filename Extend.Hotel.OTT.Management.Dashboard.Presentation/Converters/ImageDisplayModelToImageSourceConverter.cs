using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Providers;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is Service.Hotel.OTT.API.Common.Models.ImageDisplayModel)) return ConstantProvider.DEFAULT_IMAGE;

            return (value as Service.Hotel.OTT.API.Common.Models.ImageDisplayModel).ToImageSource();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
