using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class VideoDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Video, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public System.DateTime CreateAt { get; set; }

        public long Length { get; set; }

        public string About { get; set; }

        public string Extension { get; set; }

        public System.TimeSpan Duration { get; set; }

        public string Format { get; set; }

        public string FrameSize { get; set; }

        public string ColorModel { get; set; }

        public double Fps { get; set; }

        public string AudioFormat { get; set; }

        public string AudioChannelOutput { get; set; }

        public void Import(Video entity)
        {
            Id = entity.Id;
            ThumbnailId = entity.ThumbnailId ?? System.Guid.Empty;
            CreateAt = entity.CreateAt;
            Length = entity.Length;
            About = entity.About;
            Extension = entity.Extension;
            Duration = entity.Duration;
            Format = entity.Format;
            FrameSize = entity.FrameSize;
            ColorModel = entity.ColorModel;
            Fps = entity.Fps;
            AudioFormat = entity.AudioFormat;
            AudioChannelOutput = entity.AudioChannelOutput;
        }
    }
}
