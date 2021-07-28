namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions
{
    public static class ViewModelExtensions
    {
        public static Models.Context.ImageContextModel ToContextModel(this Support.Presentation.Models.View.ImageViewModel target)
        {
            var sizes = target.Resolution.Split('x');

            var result = new Models.Context.ImageContextModel
            {
                Id = target.Id,
                ThumbnailId = target.ThumbnailId,
                CreateAt = target.CreateAt,
                ContentType = string.Format("images/{0}", target.Format.ToLowerInvariant()),
                Width = int.Parse(sizes[0]),
                Height = int.Parse(sizes[1]),
                Length = target.Size,
                About = target.About
            };

            return result;
        }
        public static Models.Context.VideoContextModel ToContextModel(this Support.Presentation.Models.View.VideoViewModel target)
        {
            var sizes = target.FrameSize.Split('x');

            var result = new Models.Context.VideoContextModel
            {
                Id = target.Id,
                CreateAt = target.CreateAt,
                ThumbnailId = target.ThumbnailId,
                Extension = target.Extension,
                FrameWidth = int.Parse(sizes[0]),
                FrameHeight = int.Parse(sizes[1]),
                Length = target.Size,
                Duration = System.TimeSpan.Parse(target.Duration),
                Fps = target.Fps,
                About = target.About
            };

            return result;
        }
    }

}
