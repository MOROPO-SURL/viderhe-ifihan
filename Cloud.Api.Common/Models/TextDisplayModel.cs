using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class TextDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Text, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Content { get; set; }

        public string About { get; set; }

        public void Import(Text entity)
        {
            Id = entity.Id;
            Content = entity.Content;
            About = entity.About;
            CreateAt = entity.CreateAt;
        }
    }
}
