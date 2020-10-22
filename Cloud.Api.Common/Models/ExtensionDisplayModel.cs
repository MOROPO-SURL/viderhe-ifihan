using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class ExtensionDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Extension, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public TemplateDisplayModel[] Templates { get; set; }

        public TransitionDisplayModel[] Transitions { get; set; }

        public OverlayDisplayModel[] Overlays { get; set; }

        public void Import(Persistence.Entities.Extension entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Templates = entity.Templates.Select(e => new TemplateDisplayModel { Id = e.Id, Enabled = e.Enabled }).ToArray();
            Transitions = entity.Transitions.Select(e => new TransitionDisplayModel { Id = e.Id, Enabled = e.Enabled }).ToArray();
            Overlays = entity.Overlays.Select(e => new OverlayDisplayModel { Id = e.Id, Enabled = e.Enabled }).ToArray();
        }
    }
}
