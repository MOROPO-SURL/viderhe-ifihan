namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class ChannelInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Channel, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public Persistence.Enumerations.ChannelKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string SourceSerialization { get; set; }

        public byte[] FeatureImageContent { get; set; }

        public string FeatureImageContentType { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.Channel Export()
        {
            var entity = new Persistence.Entities.Channel();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Channel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Channel entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Kind = Kind;
            entity.SourceSerialization = SourceSerialization;
            entity.Description = Description;
        }
    }
}
