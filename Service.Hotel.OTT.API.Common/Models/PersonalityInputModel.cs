using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class PersonalityInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Personality, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public System.DateTime? BornDate { get; set; }

        public Framework.Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public string About { get; set; }

        public byte[] ImageContent { get; set; }

        public string ImageExtension { get; set; }

        public System.Guid? ImageId { get; set; }

        public Personality Export()
        {
            var entity = new Personality();

            Mergue(entity);

            return entity;
        }

        public void Import(Personality entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Personality entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.LastName = LastName;
            entity.Identity.Alias = Alias;
            entity.Identity.BornDate = BornDate;
            entity.Identity.Sex = Sex;
            entity.Identity.About = About;
        }
    }
}
