namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class CheckIn : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Number { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DepartureOperationId))]
        public Operation DepartureOperation { get; set; }
        public long DepartureOperationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ArrivalOperationId))]
        public Operation ArrivalOperation { get; set; }
        public long ArrivalOperationId { get; set; }

        public bool IsOpen { get; set; }

        public bool IsVIP { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }
    }
}
