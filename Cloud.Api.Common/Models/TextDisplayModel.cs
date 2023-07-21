namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class TextDisplayModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Text, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Content { get; set; }

        public string About { get; set; }

        public void Import(Persistence.Entities.Text entity)
        {
            Id = entity.Id;
            Content = entity.Content;
            About = entity.About;
            CreateAt = entity.CreateAt;
        }
    }
}
