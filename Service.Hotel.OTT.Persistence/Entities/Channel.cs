using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class Channel : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public ChannelKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string SourceSerialization { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("FeatureImageId")]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid? FeatureImageId { get; set; }

        public string Description { get; set; }
    }
}
