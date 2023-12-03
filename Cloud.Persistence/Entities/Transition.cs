namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Transition : Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        public Transition()
        {
            Enabled = true;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }
    }
}
