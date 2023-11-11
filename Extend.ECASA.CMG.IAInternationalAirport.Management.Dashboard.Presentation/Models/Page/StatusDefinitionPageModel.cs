namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class StatusDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string label;
        private int? discriminator;
        private int[] availableDiscriminators;

        public StatusDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Label { get => label; set => SetProperty(ref label, value); }

        public int? Discriminator { get => discriminator; set => SetProperty(ref discriminator, value); }

        public int[] AvailableDiscriminators { get => availableDiscriminators; set => SetProperty(ref availableDiscriminators, value); }
    }
}
