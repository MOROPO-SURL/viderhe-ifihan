using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class VideoInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Video, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string About { get; set; }

        public Video Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Video entity)
        {
            About = entity.About;
        }

        public void Mergue(Video entity)
        {
            entity.About = About;
        }
    }
}
