using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class PlacardDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Placard, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Label { get; set; }

        public TemplateDisplayModel Template { get; set; }

        public PlayerOrientationSupportKind? PlayerOrientationSupportKind { get; set; }

        public System.DateTime? BeginAt { get; set; }

        public System.DateTime? EndAt { get; set; }

        public string SerializedContext { get; set; }

        public PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public void Import(Placard entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            PlayerOrientationSupportKind = entity.PlayerOrientationSupportKind;
            BeginAt = entity.BeginAt;
            EndAt = entity.EndAt;
            SerializedContext = entity.SerializedContext;
            ComplementationKind = entity.ComplementationKind;
            SerializedComplementation = entity.SerializedComplementation;
            Tags = entity.TagBridges.Select(bridge => new TagDisplayModel
            {
                Id = bridge.SternId,
                Name = bridge.Stern.Name,
                Group = bridge.Stern.Group,
                Color = bridge.Stern.Color
            }).ToArray();

            Template = new TemplateDisplayModel();

            Template.Import(entity.Template);
        }
    }
}
