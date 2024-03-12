namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Overlay : Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        public Overlay()
        {
            Enabled = true;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }
    }
}
