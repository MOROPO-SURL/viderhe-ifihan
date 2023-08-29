namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Factories
{
    public static class ApiKeyDefinitionPageModelFactory
    {
        public static Models.Page.ApiKeyDefinitionPageModel Build(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.ApiKeyDisplayModel target)
        {
            if (target == null) return new Models.Page.ApiKeyDefinitionPageModel();

            return new Models.Page.ApiKeyDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Enabled = target.Enabled,
                HasFullAccess = target.HasFullAccess,
                Token = target.Token,
                ExpirateAt = target.ExpirateAt,
                Host = target.Host,
                Roles = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel>(target.Roles)
            };
        }
    }
}
