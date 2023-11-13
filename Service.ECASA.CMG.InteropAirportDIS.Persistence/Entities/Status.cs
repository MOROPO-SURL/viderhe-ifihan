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

        public string EmphasisTextColor { get; set; }

        public string EmphasisBackgroundColor { get; set; }

        public string AlternateTextColor { get; set; }

        public string AlternateBackgroundColor { get; set; }
    }
}