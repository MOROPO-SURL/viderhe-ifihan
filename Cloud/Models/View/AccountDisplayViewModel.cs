using MOROPO.VIDERHE.Cloud.Helpers.Integrity;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Models.View
{
    public class AccountDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Account, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int MaxPlayerCount { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }

        public System.Guid LogoImageId { get; set; }

        public System.Guid HorizontalSplashImageId { get; set; }

        public System.Guid VerticalSplashImageId { get; set; }

        public bool ValidSignature { get; set; }

        public void Import(Account entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            MaxPlayerCount = entity.MaxPlayerCount;
            CreateAt = entity.CreateAt;
            PrimaryColor = entity.PrimaryColor;
            SecoundaryColor = entity.SecoundaryColor;
            LogoImageId = entity.LogoId;
            HorizontalSplashImageId = entity.HorizontalSplashId;
            VerticalSplashImageId = entity.VerticalSplashId;
            ValidSignature = AccountIntegrityHelper.IsCorrectlySigned(entity);
        }
    }
}
