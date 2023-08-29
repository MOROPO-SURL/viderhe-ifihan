using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class ApiKeyDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ApiKey, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public bool Enabled { get; set; }

        public bool HasFullAccess { get; set; }

        public System.DateTime? ExpirateAt { get; set; }

        public string Host { get; set; }

        public RoleDisplayModel[] Roles { get; set; }

        public void Import(Persistence.Entities.ApiKey entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Token = entity.Token;
            Enabled = entity.Enabled;
            HasFullAccess = entity.HasFullAccess;
            ExpirateAt = entity.ExpirateAt;
            Host = entity.Host;
            Roles = entity.RoleBridges.Select(item => new RoleDisplayModel
            {
                Id = item.SternId,
                Name = item.Stern.Name,
                Description = item.Stern.Description
            }).ToArray();
        }
    }
}
