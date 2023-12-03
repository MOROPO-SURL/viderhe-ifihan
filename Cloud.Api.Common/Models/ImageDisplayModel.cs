using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ImageDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Image, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string About { get; set; }

        public void Import(Image entity)
        {
            Id = entity.Id;
            ThumbnailId = entity.ThumbnailId ?? System.Guid.Empty;
            CreateAt = entity.CreateAt;
            ContentType = entity.ContentType;
            Length = entity.Length;
            About = entity.About;
            Width = entity.Width;
            Height = entity.Height;
        }
    }
}
