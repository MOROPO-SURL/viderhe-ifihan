namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class ApiKeyDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ApiKey, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public bool Enabled { get; set; }

        public System.DateTime ExpirateAt { get; set; }

        public string Host { get; set; }

        public Framework.Guama.Core.Security.Common.Persistence.Entities.Permission[] UngroupedPermissions { get; set; }

        public System.Collections.Generic.KeyValuePair<string, Framework.Guama.Core.Security.Common.Persistence.Entities.Permission[]>[] GroupedPermissions { get; set; }

        public void Import(Persistence.Entities.ApiKey entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Token = entity.Token;
            Enabled = entity.Enabled;
            ExpirateAt = entity.ExpirateAt;
            Host = entity.Host;
        }
    }
}
