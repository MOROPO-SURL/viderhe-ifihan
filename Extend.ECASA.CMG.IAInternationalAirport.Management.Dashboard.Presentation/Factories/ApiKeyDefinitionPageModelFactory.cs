namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class ApiKeyDefinitionPageModelFactory
    {
        public static Models.Page.ApiKeyDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ApiKeyDisplayModel target)
        {
            if (target == null) return new Models.Page.ApiKeyDefinitionPageModel();

            var model = new Models.Page.ApiKeyDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Enabled = target.Enabled,
                HasFullAccess = target.HasFullAccess,
                Token = target.Token,
                IsExpirable = target.ExpirateAt != null,
                Host = target.Host,
                Roles = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.RoleDisplayModel>(target.Roles)
            };

            if (model.IsExpirable)
            {
                model.ExpirateAtDate = target.ExpirateAt.Value.Date;
                model.ExpirateAtTime = target.ExpirateAt.Value.TimeOfDay;
            }

            return model;
        }
    }
}
