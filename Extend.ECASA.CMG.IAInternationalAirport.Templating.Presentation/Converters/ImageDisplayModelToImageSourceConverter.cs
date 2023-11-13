using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Converters
{
    public class ImageDisplayModelToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public Views.Facade.IInteroperablePlacardFacade InteroperablePlacard { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel)) return Providers.ConstantProvider.DEFAULT_IMAGE;

            return (value as MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel).ToImageSource(InteroperablePlacard.GetInteroperableModel());
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
