using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class CarrierDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private Xamarin.Forms.ImageSource imageSource;
        private CountryDisplayModel country;
        private Xamarin.Forms.Color primaryColor;
        private Xamarin.Forms.Color secoundaryColor;
        private CountryDisplayModel[] selectableCountries;

        public string Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public Xamarin.Forms.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }

        public CountryDisplayModel Country { get => country; set => SetProperty(ref country, value); }

        public Xamarin.Forms.Color PrimaryColor { get => primaryColor; set => SetProperty(ref primaryColor, value); }

        public Xamarin.Forms.Color SecoundaryColor { get => secoundaryColor; set => SetProperty(ref secoundaryColor, value); }

        public CountryDisplayModel[] SelectableCountries { get => selectableCountries; set => SetProperty(ref selectableCountries, value); }
    }
}
