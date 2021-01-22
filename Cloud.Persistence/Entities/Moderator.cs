namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Moderator : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Moderator()
        {
            Id = System.Guid.NewGuid();
            Identity = new SAPRESSC.Middleware.Identity.Persistence.Entities.PersonIdentity();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public System.Guid IdentityId { get; set; }

        public SAPRESSC.Middleware.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }

        public string UserId { get; set; }

        public SAPRESSC.Core.Security.Persistence.Entities.User User { get; set; }
    }
}
