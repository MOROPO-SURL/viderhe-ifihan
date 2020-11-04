namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Extensions
{
    public static class ContextModelExtensions
    {
        public static Support.Presentation.Models.View.ImageViewModel ToViewModel(this Models.Context.ImageContextModel target)
        {
            return new Support.Presentation.Models.View.ImageViewModel
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

        public static Support.Presentation.Models.View.VideoViewModel ToViewModel(this Models.Context.VideoContextModel target)
        {
            return new Support.Presentation.Models.View.VideoViewModel
            {
                Id = target.Id,
                FrameSize = string.Format("{0}x{1}", target.FrameWidth, target.FrameHeight),
                ThumbnailId = target.ThumbnailId,
                Extension = target.Extension
            };
        }
    }
}
