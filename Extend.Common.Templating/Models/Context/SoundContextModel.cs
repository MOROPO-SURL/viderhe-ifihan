namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Models.Context
{
    public class SoundContextModel
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Extension { get; set; }

        public long Length { get; set; }

        public string About { get; set; }

        public System.TimeSpan Duration { get; set; }

        public string AudioFormat { get; set; }

        public string AudioChannelOutput { get; set; }

        public System.Guid? ThumbnailId { get; set; }

        public string ThumbnailContentType { get; set; }
    }
}
