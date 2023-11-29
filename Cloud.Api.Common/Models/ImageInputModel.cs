using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ImageInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Image, System.Guid>
    {
        public System.Guid Id { get; set; }

        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }

        public string About { get; set; }

        public Image Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Image entity)
        {
            About = entity.About;
        }

        public void Mergue(Image entity)
        {
            entity.About = About;
        }
    }
}
