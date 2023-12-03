using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Managers;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel))
            {
                return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", SessionManager.Instance.Server)));
            }

            return (value as Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel).ToImageSource();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
