using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.VIDERHE.Cloud.Models.View
{
    public class ModeratorInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Moderator, System.Guid>
    {
        public ModeratorInputViewModel()
        {
            Account = new AccountDisplayViewModel();
            SelectableUsers = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        }

        public System.Guid Id { get; set; }

        public AccountDisplayViewModel Account { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "User")]
        public string UserId { get; set; }

        public System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> SelectableUsers { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "BornDate")]
        public System.DateTime? BornDate { get; set; }

        [Display(Name = "CivilStatus")]
        public Framework.Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        [Display(Name = "Sex")]
        public Framework.Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [FormFileMaxLength(Length = 1048576, ErrorMessage = "FileLimitSizeExcededMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public bool ResetImage { get; set; }

        public System.Guid ImageId { get; set; }

        public string ImageExtension { get; set; }

        public Moderator Export()
        {
            var entity = new Moderator
            {
                UserId = UserId,
                ModerationKind = ModerationKind.Privileged
            };

            Mergue(entity);

            return entity;
        }

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

        public void Mergue(Moderator entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.LastName = LastName;
            entity.Identity.Alias = Alias;
            entity.Identity.BornDate = BornDate;
            entity.Identity.Sex = Sex;
            entity.Identity.CivilStatus = CivilStatus;
            entity.Identity.About = About;
        }
    }
}
