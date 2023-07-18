using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Text : MOROPO.SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Text()
        {
            Id = System.Guid.NewGuid();
            CreateAt = System.DateTime.Now;
            AccountBridges = new System.Collections.Generic.List<AccountTextBridge>();
        }

        [Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(255)]
        public string About { get; set; }

        public System.Collections.Generic.List<AccountTextBridge> AccountBridges { get; set; }
    }
}
