using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Gradient : MOROPO.SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Gradient()
        {
            Id = System.Guid.NewGuid();
            CreateAt = System.DateTime.Now;
            AccountBridges = new System.Collections.Generic.List<AccountGradientBridge>();
        }

        [Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [Required]
        public string Data { get; set; }

        [MaxLength(255)]
        public string About { get; set; }

        public System.Collections.Generic.List<AccountGradientBridge> AccountBridges { get; set; }
    }
}
