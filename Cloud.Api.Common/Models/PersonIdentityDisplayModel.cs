using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class PersonIdentityDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<PersonIdentity, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public System.DateTime? BornDate { get; set; }

        public CivilStatus CivilStatus { get; set; }

        public Sex Sex { get; set; }

        public string Alias { get; set; }

        public string About { get; set; }

        public ImageDisplayModel Image { get; set; }

        public void Import(PersonIdentity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LastName = entity.LastName;
            BornDate = entity.BornDate;
            CivilStatus = entity.CivilStatus;
            Sex = entity.Sex;
            Alias = entity.Alias;
            About = entity.About;

            if (entity.Image != null)
            {
                Image = new ImageDisplayModel();

                Image.Import(entity.Image);
            }
        }
    }
}
