using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Sound : MOROPO.SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Sound()
        {
            Id = System.Guid.NewGuid();
            CreateAt = System.DateTime.Now;
        }

        [Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [Required]
        public string Extension { get; set; }

        public long Length { get; set; }

        [MaxLength(255)]
        public string About { get; set; }

        public System.TimeSpan Duration { get; set; }

        public string AudioFormat { get; set; }

        public string AudioChannelOutput { get; set; }

        public MOROPO.SAPRESSC.Middleware.Media.Persistence.Entities.Thumbnail Thumbnail { get; set; }

        public System.Guid? ThumbnailId { get; set; }
    }
}
