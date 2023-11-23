using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public Views.Placard.Facade.IInteroperablePlacardFacade InteroperablePlacard { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel))
            {
                return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", InteroperablePlacard.GetInteroperableModel().APIServer)));
            }

            return (value as MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel).ToImageSource(InteroperablePlacard.GetInteroperableModel());
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
