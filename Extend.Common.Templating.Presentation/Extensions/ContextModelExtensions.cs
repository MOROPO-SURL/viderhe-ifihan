using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions
{
    public static class ContextModelExtensions
    {
        public static ImageViewModel ToViewModel(this ImageContextModel target)
        {
            return new ImageViewModel
            {
                Id = target.Id,
                ThumbnailId = target.ThumbnailId,
                CreateAt = target.CreateAt,
                Format = target.ContentType.Split('/')[1].ToUpperInvariant(),
                Resolution = string.Format("{0}x{1}", target.Width, target.Height),
                Size = target.Length,
                About = target.About
            };
        }

        public static VideoViewModel ToViewModel(this VideoContextModel target)
        {
            return new VideoViewModel
            {
                Id = target.Id,
                CreateAt = target.CreateAt,
                FrameSize = string.Format("{0}x{1}", target.FrameWidth, target.FrameHeight),
                ThumbnailId = target.ThumbnailId,
                Extension = target.Extension,
                Size = target.Length,
                Duration = target.Duration.ToString(),
                Fps = target.Fps,
                About = target.About
            };
        }
    }
}
