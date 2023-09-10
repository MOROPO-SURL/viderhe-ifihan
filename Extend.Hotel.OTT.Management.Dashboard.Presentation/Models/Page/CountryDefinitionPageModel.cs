namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class CountryDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private string isoCode;

        public CountryDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string IsoCode { get => isoCode; set => SetProperty(ref isoCode, value); }
    }
}
