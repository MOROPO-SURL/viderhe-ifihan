namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Factories
{
    public static class RoleDefinitionPageModelFactory
    {
        public static Models.Page.RoleDefinitionPageModel Build(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel target)
        {
            if (target == null) return new Models.Page.RoleDefinitionPageModel();

            return new Models.Page.RoleDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Description = target.Description
            };
        }
    }
}
