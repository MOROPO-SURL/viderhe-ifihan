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
    }
}
