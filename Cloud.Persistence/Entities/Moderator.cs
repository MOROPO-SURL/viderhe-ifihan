namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Moderator : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Moderator()
        {
            Id = System.Guid.NewGuid();
            ModerationKind = Enumerations.ModerationKind.Standard;
            Identity = new Framework.Guama.Identity.Persistence.Entities.PersonIdentity();
            AccountBridges = new System.Collections.Generic.List<AccountModeratorBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public System.Guid IdentityId { get; set; }

        public Framework.Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }

        public string UserId { get; set; }

        public Framework.Guama.Security.Essential.Persistence.Entities.User User { get; set; }

        public Enumerations.ModerationKind ModerationKind { get; set; }

        public System.Collections.Generic.List<AccountModeratorBridge> AccountBridges { get; set; }
    }
}