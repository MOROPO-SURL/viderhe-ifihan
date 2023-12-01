using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Models.View
{
    public class ModeratorDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Moderator, System.Guid>
    {
        public System.Guid Id { get; set; }

        public AccountDisplayViewModel Account { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public System.DateTime? BornDate { get; set; }

        public Framework.Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        public Framework.Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public string About { get; set; }

        public System.Guid ImageId { get; set; }

        public string ImageExtension { get; set; }

        public void Import(Moderator entity)
        {
            Id = entity.Id;
            UserId = entity.UserId;
            Name = entity.Identity.Name;
            LastName = entity.Identity.LastName;
            Alias = entity.Identity.Alias;
            BornDate = entity.Identity.BornDate;
            CivilStatus = entity.Identity.CivilStatus;
            Sex = entity.Identity.Sex;
            About = entity.Identity.About;
            ImageId = entity.Identity.ImageId ?? System.Guid.Empty;
            ImageExtension = entity.Identity.Image == null ? null : MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
        }
    }
}
