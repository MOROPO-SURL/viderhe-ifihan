using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class ApiKeyDefinitionPageModelFactory
    {
        public static ApiKeyDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.ApiKeyDisplayModel target)
        {
            if (target == null) return new ApiKeyDefinitionPageModel();

            var model = new ApiKeyDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Enabled = target.Enabled,
                HasFullAccess = target.HasFullAccess,
                Token = target.Token,
                IsExpirable = target.ExpirateAt != null,
                Host = target.Host,
                Roles = new System.Collections.ObjectModel.ObservableCollection<Service.Hotel.OTT.API.Common.Models.RoleDisplayModel>(target.Roles)
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
