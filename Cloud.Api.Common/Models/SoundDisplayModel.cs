namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class SoundDisplayModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Sound, System.Guid>
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

        public void Import(Persistence.Entities.Sound entity)
        {
            Id = entity.Id;
            CreateAt = entity.CreateAt;
            Extension = entity.Extension;
            Length = entity.Length;
            About = entity.About;
            Duration = entity.Duration;
            AudioFormat = entity.AudioFormat;
            AudioChannelOutput = entity.AudioChannelOutput;
            ThumbnailId = entity.ThumbnailId;
        }
    }
}
