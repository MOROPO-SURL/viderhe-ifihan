using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class TerminalDefinitionPageModelFactory
    {
        public static TerminalDefinitionPageModel Build(Service.ECASA.CMG.InterFIDS.API.Common.Models.TerminalDisplayModel target)
        {
            if (target == null) return new TerminalDefinitionPageModel();

            return new TerminalDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Discriminator = target.Discriminator
            };
        }
    }
}
