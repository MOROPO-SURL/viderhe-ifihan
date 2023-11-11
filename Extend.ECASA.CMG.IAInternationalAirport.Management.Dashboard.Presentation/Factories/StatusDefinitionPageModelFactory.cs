namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class StatusDefinitionPageModelFactory
    {
        public static Models.Page.StatusDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.StatusDisplayModel target)
        {
            if (target == null) return new Models.Page.StatusDefinitionPageModel();

            return new Models.Page.StatusDefinitionPageModel
            {
                Id = target.Id,
                Label = target.Label,
                Discriminator = target.Discriminator
            };
        }
    }
}
