namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class Status : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Status()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Discriminator { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Label { get; set; }
    }
}