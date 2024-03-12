using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class AccountInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Account, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string PrimaryColor { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string SecoundaryColor { get; set; }

        public byte[] LogoImageData { get; set; }

        public string LogoImageContentType { get; set; }

        public System.Guid LogoImageId { get; set; }

        public byte[] HorizontalSplashImageData { get; set; }

        public string HorizontalSplashImageContentType { get; set; }

        public System.Guid HorizontalSplashImageId { get; set; }

        public byte[] VerticalSplashImageData { get; set; }

        public string VerticalSplashImageContentType { get; set; }

        public System.Guid VerticalSplashImageId { get; set; }

        public System.Guid? DefaultOverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }

        public Account Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Account entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Account entity)
        {
            entity.Name = Name;
            entity.PrimaryColor = PrimaryColor;
            entity.SecoundaryColor = SecoundaryColor;
            entity.DefaultOverlayId = DefaultOverlayId;
            entity.SerializedOverlayContext = SerializedOverlayContext;
        }
    }
}
