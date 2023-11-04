using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel)) return Providers.ConstantProvider.DEFAULT_IMAGE;

            return (value as MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel).ToImageSource();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
