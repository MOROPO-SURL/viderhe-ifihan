namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class GradientInputModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Gradient, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Data { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public Persistence.Entities.Gradient Export()
        {
            var entity = new Persistence.Entities.Gradient();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Gradient entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Gradient entity)
        {
            entity.Data = Data;
            entity.About = About;
        }
    }
}
