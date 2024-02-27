using MOROPO.Framework.Guama.Security.Essential.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class UserDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<User, string>
    {
        public string Id { get; set; }

        public bool Enabled { get; set; }

        public bool PasswordChangeRequired { get; set; }

        public System.DateTime Created { get; set; }

        public System.DateTime LastSessionDate { get; set; }

        public int FailAuthenticationCount { get; set; }

        public void Import(User entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            PasswordChangeRequired = entity.PasswordChangeRequired;
            Created = entity.Created;
            LastSessionDate = entity.LastSessionDate;
            FailAuthenticationCount = entity.FailAuthenticationCount;
        }
    }
}
