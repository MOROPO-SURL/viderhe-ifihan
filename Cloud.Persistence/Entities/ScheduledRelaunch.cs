namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class ScheduledRelaunch : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string PlayerId { get; set; }
        public Player Player { get; set; }

        public System.TimeSpan Time { get; set; }
    }
}
