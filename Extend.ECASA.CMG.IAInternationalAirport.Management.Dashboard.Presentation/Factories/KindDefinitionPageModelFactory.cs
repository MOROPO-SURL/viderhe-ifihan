using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class KindDefinitionPageModelFactory
    {
        public static KindDefinitionPageModel Build(Service.ECASA.CMG.InterFIDS.API.Common.Models.KindDisplayModel target)
        {
            if (target == null) return new KindDefinitionPageModel();

            return new KindDefinitionPageModel
            {
                Id = target.Id,
                Discriminator = target.Discriminator
            };
        }
    }
}
