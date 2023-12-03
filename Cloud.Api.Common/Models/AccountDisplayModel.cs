using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class AccountDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Account, System.Guid>
    {
        public AccountDisplayModel()
        {
            Extensions = new System.Collections.Generic.List<ExtensionDisplayModel>();
        }

        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }

        public System.Guid? DefaultOverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }

        public System.Collections.Generic.List<ExtensionDisplayModel> Extensions { get; set; }

        public void Import(Account entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            PrimaryColor = entity.PrimaryColor;
            SecoundaryColor = entity.SecoundaryColor;
            DefaultOverlayId = entity.DefaultOverlayId;
            SerializedOverlayContext = entity.SerializedOverlayContext;
        }
    }
}
