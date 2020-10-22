namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class VideoInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<SAPRESSC.Middleware.Media.Persistence.Entities.Video, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string About { get; set; }

        public SAPRESSC.Middleware.Media.Persistence.Entities.Video Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(SAPRESSC.Middleware.Media.Persistence.Entities.Video entity)
        {
            About = entity.About;
        }

        public void Mergue(SAPRESSC.Middleware.Media.Persistence.Entities.Video entity)
        {
            entity.About = About;
        }
    }
}
