namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class Operation : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CarrierId")]
        public Carrier Carrier { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string CarrierId { get; set; }

        public int Flight { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Context { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Gate { get; set; }

        public System.DateTime Date { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TerminalId")]
        public Terminal Terminal { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? TerminalId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("KindId")]
        public Kind Kind { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public Enumerations.OperationKind? KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("StatusId")]
        public Status Status { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? StatusId { get; set; }
    }
}
