namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class CheckIn : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("OperationId")]
        public Operation Operation { get; set; }
        public long OperationId { get; set; }

        public bool IsOpen { get; set; }

        public bool IsVIP { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }
    }
}
