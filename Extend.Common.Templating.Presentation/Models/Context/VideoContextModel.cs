namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Models.Context
{
    public class VideoContextModel
    {
        public System.Guid Id { get; set; }

        public string Extension { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public string ThumbnailContentType { get; set; }
    }
}
