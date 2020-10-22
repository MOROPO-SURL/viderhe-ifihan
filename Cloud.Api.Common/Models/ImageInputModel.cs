namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class ImageInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<SAPRESSC.Middleware.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string About { get; set; }

        public SAPRESSC.Middleware.Media.Persistence.Entities.Image Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(SAPRESSC.Middleware.Media.Persistence.Entities.Image entity)
        {
            About = entity.About;
        }

        public void Mergue(SAPRESSC.Middleware.Media.Persistence.Entities.Image entity)
        {
            entity.About = About;
        }
    }
}
