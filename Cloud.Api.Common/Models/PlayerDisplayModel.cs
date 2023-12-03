using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class PlayerDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Player, string>
    {
        public PlayerDisplayModel()
        {
            IsConnected = false;
            AudioEnabled = false;
            AudioLevel = -1;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public ScreenplayDisplayModel Screenplay { get; set; }

        public System.Guid? OverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }

        public bool IsConnected { get; set; }

        public int AudioLevel { get; set; }

        public bool AudioEnabled { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public void Import(Player entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            About = entity.About;
            OverlayId = entity.OverlayId;
            SerializedOverlayContext = entity.SerializedOverlayContext;
            Tags = entity.TagBridges.Select(bridge => new TagDisplayModel
            {
                Id = bridge.SternId,
                Name = bridge.Stern.Name,
                Group = bridge.Stern.Group,
                Color = bridge.Stern.Color
            }).ToArray();

            if (entity.Screenplay == null) return;

            Screenplay = new ScreenplayDisplayModel();

            Screenplay.Import(entity.Screenplay);
        }
    }
}
