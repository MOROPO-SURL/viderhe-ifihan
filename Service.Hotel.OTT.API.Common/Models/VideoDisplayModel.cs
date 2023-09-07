namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class VideoDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Framework.Guama.Media.Persistence.Entities.Video, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Extension { get; set; }

        public string About { get; set; }

        public void Import(Framework.Guama.Media.Persistence.Entities.Video entity)
        {
            Id = entity.Id;
            Extension = entity.Extension;
            About = entity.About;
        }
    }
}
