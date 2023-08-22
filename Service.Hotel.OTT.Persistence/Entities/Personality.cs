namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class Personality : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdentityId")]
        public Framework.Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? IdentityId { get; set; }
    }
}
