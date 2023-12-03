namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class CategoryDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private int? discriminator;
        private int[] availableDiscriminators;

        public CategoryDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public int? Discriminator { get => discriminator; set => SetProperty(ref discriminator, value); }

        public int[] AvailableDiscriminators { get => availableDiscriminators; set => SetProperty(ref availableDiscriminators, value); }
    }
}
