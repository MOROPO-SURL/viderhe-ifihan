namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class GradientDisplayModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Gradient, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Data { get; set; }

        public string About { get; set; }

        public void Import(Persistence.Entities.Gradient entity)
        {
            Id = entity.Id;
            CreateAt = entity.CreateAt;
            Data = entity.Data;
            About = entity.About;
        }
    }
}
