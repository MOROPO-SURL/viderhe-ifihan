using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ModeratorDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Moderator, System.Guid>
    {
        public System.Guid Id { get; set; }

        public UserDisplayModel User { get; set; }

        public PersonIdentityDisplayModel Identity { get; set; }

        public bool IsPrivileged { get; set; }

        public void Import(Moderator entity)
        {
            Id = entity.Id;
            User = new UserDisplayModel();
            Identity = new PersonIdentityDisplayModel();
            IsPrivileged = entity.ModerationKind == ModerationKind.Privileged;

            User.Import(entity.User);

            Identity.Import(entity.Identity);
        }
    }
}
