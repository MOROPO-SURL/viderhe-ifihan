namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Models.Context
{
    public class VideoContextModel
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Extension { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public string ThumbnailContentType { get; set; }

        public long Length { get; set; }

        public System.TimeSpan Duration { get; set; }

        public double Fps { get; set; }

        public string About { get; set; }
    }
}
