using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class TransitionDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Transition, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public void Import(Transition entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
        }
    }
}
