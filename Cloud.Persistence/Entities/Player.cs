using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class Player : INamedEntity<string>, IPersistenceSignable
    {   
        [Key, RegularExpression(@"^[0-9A-Z]{7}$")]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public System.Guid AccountId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AccountId")]
        public Account Account { get; set; }

        public System.Guid? ScreenplayId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ScreenplayId")]
        public Screenplay Screenplay { get; set; }

        public System.Guid? OverlayId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("OverlayId")]

        public Overlay Overlay { get; set; }

        public string SerializedOverlayContext { get; set; }

        public string About { get; set; }

        [Required]
        public string Signature { get; set; }

        public object GetSignableEntityModel()
        {
            return new { Id, Name, AccountId = Account.Id };
        }
    }
}
