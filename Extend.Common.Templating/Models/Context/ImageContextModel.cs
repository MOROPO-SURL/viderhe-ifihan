namespace MOROPO.VIDERHE.Extend.Common.Templating.Models.Context
{
    public class ImageContextModel
    {
        public System.Guid Id { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string About { get; set; }
    }
}
