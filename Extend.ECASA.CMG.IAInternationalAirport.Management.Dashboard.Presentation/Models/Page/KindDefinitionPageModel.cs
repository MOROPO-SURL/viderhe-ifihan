namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class KindDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string discriminator;
        private Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind[] availableIds;

        public Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind? Id { get; set; }

        public string Discriminator { get => discriminator; set => SetProperty(ref discriminator, value); }

        public Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind[] AvailableIds { get => availableIds; set => SetProperty(ref availableIds, value); }
    }
}