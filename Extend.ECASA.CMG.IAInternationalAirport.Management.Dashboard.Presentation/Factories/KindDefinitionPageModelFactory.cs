namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class KindDefinitionPageModelFactory
    {
        public static Models.Page.KindDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.KindDisplayModel target)
        {
            if (target == null) return new Models.Page.KindDefinitionPageModel();

            return new Models.Page.KindDefinitionPageModel
            {
                Id = target.Id,
                Discriminator = target.Discriminator
            };
        }
    }
}
