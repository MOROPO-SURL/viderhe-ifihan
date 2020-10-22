using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class Frame : SAPRESSC.Core.Persistence.Entities.IEntity<long>
    {
        [Key]
        public long Id { get; set; }

        public System.Guid ScreenplayId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ScreenplayId")]
        public Screenplay Screenplay { get; set; }

        public System.Guid PlacardId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PlacardId")]
        public Placard Placard { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
