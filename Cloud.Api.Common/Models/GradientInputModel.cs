using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class GradientInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Gradient, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Data { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public Gradient Export()
        {
            var entity = new Gradient();

            Mergue(entity);

            return entity;
        }

        public void Import(Gradient entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Gradient entity)
        {
            entity.Data = Data;
            entity.About = About;
        }
    }
}
