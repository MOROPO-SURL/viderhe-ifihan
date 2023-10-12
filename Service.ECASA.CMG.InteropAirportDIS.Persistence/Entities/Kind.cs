namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class Kind : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<Enumerations.OperationKind>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Enumerations.OperationKind Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Discriminator { get; set; }
    }
}
