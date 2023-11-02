namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class CountryDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private ISO3166.Country country;
        private string localizedName;

        public CountryDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public ISO3166.Country Country { get => country; set => SetProperty(ref country, value); }

        public string LocalizedName { get => localizedName; set => SetProperty(ref localizedName, value); }

        public ISO3166.Country[] SelectableCountries { get; set; } 
    }
}
