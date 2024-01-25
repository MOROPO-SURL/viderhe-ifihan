using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ModeratorInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Moderator, System.Guid>
    {
        public System.Guid Id { get; set; }

        public UserInputModel User { get; set; }

        public PersonIdentityInputModel Identity { get; set; }

        public bool IsPrivileged { get; set; }

        public Moderator Export()
        {
            var entity = new Moderator
            {
                User = new Framework.Guama.Security.Essential.Persistence.Entities.User
                {
                    Id = User.Id,
                    FailAuthenticationCount = 0,
                    HasFullAccess = false
                },
                Identity = new Framework.Guama.Identity.Persistence.Entities.PersonIdentity()
            };

            entity.UserId = entity.User.Id;
            entity.IdentityId = entity.Identity.Id;

            Mergue(entity);

            return entity;
        }

        public void Import(Moderator entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Moderator entity)
        {
            entity.ModerationKind = IsPrivileged ? ModerationKind.Privileged : ModerationKind.Standard;
            entity.User.Enabled = User.Enabled;
            entity.User.PasswordChangeRequired = User.PasswordChangeRequired;
            entity.Identity.Name = Identity.Name;
            entity.Identity.LastName = Identity.LastName;
            //entity.Identity.BornDate = Identity.BornDate;
            //entity.Identity.Alias = Identity.Alias;
            //entity.Identity.CivilStatus = Identity.CivilStatus;
            entity.Identity.Sex = Identity.Sex;
            entity.Identity.About = Identity.About;
        }
    }
}
