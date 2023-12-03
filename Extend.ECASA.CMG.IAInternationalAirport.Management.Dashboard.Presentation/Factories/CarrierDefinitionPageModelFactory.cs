using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class CarrierDefinitionPageModelFactory
    {
        public static Models.Page.CarrierDefinitionPageModel Build(Service.ECASA.CMG.InterFIDS.API.Common.Models.CarrierDisplayModel target)
        {
            if (target == null) return new Models.Page.CarrierDefinitionPageModel();

            return new Models.Page.CarrierDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Country = target.Country,
                ImageId = target.Image?.Id,
                ImageExtension = target.Image?.Extension,
                ImageSource = target.Image?.ToImageSource(),
                PrimaryColor = Xamarin.Forms.Color.FromHex(target.PrimaryColor),
                SecoundaryColor = Xamarin.Forms.Color.FromHex(target.SecoundaryColor)
            };
        }
    }
}
