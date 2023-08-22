using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVParticipation : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public AVProductionRole Role { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PersonalityId")]
        public Personality Personality { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? PersonalityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProductionId")]
        public AVProduction Production { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProductionId { get; set; }

        public string Specification { get; set; }
    }
}
