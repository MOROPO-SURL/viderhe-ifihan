namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class ApiKeyInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ApiKey, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Token { get; set; }

        public bool Enabled { get; set; }

        public bool HasFullAccess { get; set; }

        public System.DateTime? ExpirateAt { get; set; }

        public string Host { get; set; }

        public RoleDisplayModel[] Roles { get; set; }

        public Persistence.Entities.ApiKey Export()
        {
            var entity = new Persistence.Entities.ApiKey();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ApiKey entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ApiKey entity)
        {
            entity.Name = Name;
            entity.Token = Token;
            entity.ExpirateAt = ExpirateAt;
            entity.Enabled = Enabled;
            entity.HasFullAccess = HasFullAccess;
            entity.Host = Host;
        }
    }
}
