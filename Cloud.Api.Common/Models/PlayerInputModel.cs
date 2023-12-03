using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class PlayerInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Player, string>
    {
        [Required, RegularExpression(@"^[0-9A-Z]{7}$")]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public System.Guid ScreenplayId { get; set; }

        public System.Guid? OverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }

        public string About { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public Player Export()
        {
            var entity = new Player
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Player entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            About = entity.About;
            ScreenplayId = entity.ScreenplayId ?? System.Guid.Empty;
            OverlayId = entity.OverlayId;
            SerializedOverlayContext = entity.SerializedOverlayContext;
        }

        public void Mergue(Player entity)
        {
            entity.Name = Name;
            entity.About = About;
            entity.OverlayId = OverlayId;
            entity.SerializedOverlayContext = SerializedOverlayContext;

            entity.TagBridges.Clear();

            foreach (var item in Tags)
            {
                entity.TagBridges.Add(new PlayerTagBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }
        }
    }
}
