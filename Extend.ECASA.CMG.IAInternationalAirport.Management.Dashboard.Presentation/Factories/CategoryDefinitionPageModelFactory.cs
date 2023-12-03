using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class CategoryDefinitionPageModelFactory
    {
        public static CategoryDefinitionPageModel Build(Service.ECASA.CMG.InterFIDS.API.Common.Models.CategoryDisplayModel target)
        {
            if (target == null) return new CategoryDefinitionPageModel();

            return new CategoryDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Discriminator = target.Discriminator
            };
        }
    }
}
