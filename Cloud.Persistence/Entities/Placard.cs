using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Placard : MOROPO.SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Placard()
        {
            Id = System.Guid.NewGuid();

            CreateAt = System.DateTime.Now;

            ImageBridges = new List<PlacardImageBridge>();
            VideoBridges = new List<PlacardVideoBridge>();
            SoundBridges = new List<PlacardSoundBridge>();
            GradientBridges = new List<PlacardGradientBridge>();
            TagBridges = new List<PlacardTagBridge>();
        }

        [Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public System.Guid AccountId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AccountId")]
        public Account Account { get; set; }

        [Required]
        public string Label { get; set; }

        public System.Guid TemplateId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TemplateId")]
        public Template Template { get; set; }

        public Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind? PlayerOrientationSupportKind { get; set; }

        public System.DateTime? BeginAt { get; set; }

        public System.DateTime? EndAt { get; set; }

        [Required]
        public string SerializedContext { get; set; }

        public Enumerations.PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }

        public List<PlacardImageBridge> ImageBridges { get; set; }

        public List<PlacardVideoBridge> VideoBridges { get; set; }

        public List<PlacardSoundBridge> SoundBridges { get; set; }

        public List<PlacardGradientBridge> GradientBridges { get; set; }

        public List<PlacardTagBridge> TagBridges { get; set; }
    }
}