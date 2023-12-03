using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class OverlayDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Overlay, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public void Import(Overlay entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
        }
    }
}
