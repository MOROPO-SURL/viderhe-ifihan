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

        public ImageDisplayModel FeatureImage { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.Channel entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Kind = entity.Kind;
            SourceSerialization = entity.SourceSerialization;
            Description = entity.Description;

            if (entity.FeatureImageId != null)
            {
                FeatureImage = new ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }
        }
    }
}
