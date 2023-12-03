namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Screenplay : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string About { get; set; }

        public System.Guid AccountId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AccountId")]
        public Account Account { get; set; }

        public System.Collections.Generic.List<Frame> Frames { get; set; }

        public Screenplay()
        {
            Id = System.Guid.NewGuid();

            Frames = new System.Collections.Generic.List<Frame>();
        }
    }
}
