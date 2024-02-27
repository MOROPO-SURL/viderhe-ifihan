using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class GradientDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Gradient, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Data { get; set; }

        public string About { get; set; }

        public void Import(Gradient entity)
        {
            Id = entity.Id;
            CreateAt = entity.CreateAt;
            Data = entity.Data;
            About = entity.About;
        }
    }
}
