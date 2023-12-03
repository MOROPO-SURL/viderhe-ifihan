using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class PersonIdentityInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PersonIdentity, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        public System.DateTime? BornDate { get; set; }

        public CivilStatus CivilStatus { get; set; }

        public Sex Sex { get; set; }

        public string Alias { get; set; }

        public ImageInputModel Image { get; set; }

        public string About { get; set; }

        public PersonIdentity Export()
        {
            var entity = new PersonIdentity();

            Mergue(entity);

            return entity;
        }

        public void Import(PersonIdentity entity)
        {
            throw new System.InvalidOperationException();
        }

        public void Mergue(PersonIdentity entity)
        {
            entity.Name = Name;
            entity.LastName = LastName;
            entity.BornDate = BornDate;
            entity.CivilStatus = CivilStatus;
            entity.Sex = Sex;
            entity.Alias = Alias;
            entity.About = About;
        }
    }
}
