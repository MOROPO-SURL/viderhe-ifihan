using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class PlacardInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Placard, System.Guid>
    {
        public System.Guid Id { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public System.Guid TemplateId { get; set; }

        [Required]
        public string SerializedContext { get; set; }

        public Persistence.Entities.Placard Export()
        {
            var entity = new Persistence.Entities.Placard();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Placard entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            TemplateId = entity.TemplateId;
            SerializedContext = entity.SerializedContext;
        }

        public void Mergue(Persistence.Entities.Placard entity)
        {
            entity.Label = Label;
            entity.SerializedContext = SerializedContext;
        }
    }
}
