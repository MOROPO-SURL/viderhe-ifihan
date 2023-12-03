namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Gradient : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Gradient()
        {
            Id = System.Guid.NewGuid();
            CreateAt = System.DateTime.Now;
            AccountBridges = new System.Collections.Generic.List<AccountGradientBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Data { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public System.Collections.Generic.List<AccountGradientBridge> AccountBridges { get; set; }
    }
}
