namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class Carrier : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[A-Z]{3}$")]
        public string Id { get; set; }

        public Framework.Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid? IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CountryId")]
        public Framework.Guama.Location.Persistence.Entities.Country Country { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CountryId { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }
    }
}
