using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Placard : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
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

        [Required]
        public string SerializedContext { get; set; }

        public Placard()
        {
            Id = System.Guid.NewGuid();

            CreateAt = System.DateTime.Now;
        }
    }
}
