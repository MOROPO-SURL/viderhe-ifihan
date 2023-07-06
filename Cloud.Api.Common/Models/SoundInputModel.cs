namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class SoundInputModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Sound, System.Guid>
    {
        public System.Guid Id { get; set; }

        public byte[] ContentData { get; set; }

        public string Extension { get; set; }

        public string About { get; set; }

        public void Import(Persistence.Entities.Sound entity)
        {
            throw new System.NotImplementedException();
        }

        public Persistence.Entities.Sound Export()
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Sound entity)
        {
            entity.About = About;
        }
    }
}
