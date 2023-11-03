namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class TerminalDefinitionPageModelFactory
    {
        public static Models.Page.TerminalDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.TerminalDisplayModel target)
        {
            if (target == null) return new Models.Page.TerminalDefinitionPageModel();

            return new Models.Page.TerminalDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Discriminator = target.Discriminator
            };
        }
    }
}
