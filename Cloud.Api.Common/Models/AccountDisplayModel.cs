namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class AccountDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Account, System.Guid>
    {
        public AccountDisplayModel()
        {
            Extensions = new System.Collections.Generic.List<ExtensionDisplayModel>();
        }

        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public System.Guid LogoImageId { get; set; }

        public System.Guid SplashImageId { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }

        public System.Guid? DefaultOverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }

        public System.Collections.Generic.List<ExtensionDisplayModel> Extensions { get; set; }

        public void Import(Persistence.Entities.Account entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LogoImageId = entity.LogoId;
            SplashImageId = entity.SplashId;
            PrimaryColor = entity.PrimaryColor;
            SecoundaryColor = entity.SecoundaryColor;
            DefaultOverlayId = entity.DefaultOverlayId;
            SerializedOverlayContext = entity.SerializedOverlayContext;
        }
    }
}
