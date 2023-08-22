namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class ChannelDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Channel, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public Persistence.Enumerations.ChannelKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string SourceSerialization { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string FeatureImageExtension { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.Channel entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Kind = entity.Kind;
            SourceSerialization = entity.SourceSerialization;
            FeatureImageId = entity.FeatureImageId;
            Description = entity.Description;
        }
    }
}
