using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class SoundInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Sound, System.Guid>
    {
        public System.Guid Id { get; set; }

        public byte[] ContentData { get; set; }

        public string Extension { get; set; }

        public string About { get; set; }

        public void Import(Sound entity)
        {
            throw new System.NotImplementedException();
        }

        public Sound Export()
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Sound entity)
        {
            entity.About = About;
        }
    }
}
