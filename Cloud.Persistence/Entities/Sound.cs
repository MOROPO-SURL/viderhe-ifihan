namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Sound : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Sound()
        {
            Id = System.Guid.NewGuid();
            CreateAt = System.DateTime.Now;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Extension { get; set; }

        public long Length { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public System.TimeSpan Duration { get; set; }

        public string AudioFormat { get; set; }

        public string AudioChannelOutput { get; set; }

        public Framework.Guama.Media.Persistence.Entities.Thumbnail Thumbnail { get; set; }

        public System.Guid? ThumbnailId { get; set; }
    }
}
