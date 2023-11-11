namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class CategoryDefinitionPageModelFactory
    {
        public static Models.Page.CategoryDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.CategoryDisplayModel target)
        {
            if (target == null) return new Models.Page.CategoryDefinitionPageModel();

            return new Models.Page.CategoryDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Discriminator = target.Discriminator
            };
        }
    }
}
