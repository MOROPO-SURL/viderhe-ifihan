namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class OperationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Operation, long>
    {
        public long Id { get; set; }

        public CarrierDisplayModel Carrier { get; set; }
        
        public int Flight { get; set; }

        public string Context { get; set; }

        public System.DateTime StarDate { get; set; }

        public System.DateTime? EndDate { get; set; }

        public TerminalDisplayModel Terminal { get; set; }
        
        public KindDisplayModel Kind { get; set; }
        
        public CategoryDisplayModel Category { get; set; }
        
        public StatusDisplayModel Status { get; set; }

        public void Import(Persistence.Entities.Operation entity)
        {
            Id = entity.Id;
            Flight = entity.Flight;
            Context = entity.Context;
            StarDate = entity.StarDate;
            EndDate = entity.EndDate;

            Carrier = new CarrierDisplayModel();
            Terminal = new TerminalDisplayModel();
            Kind = new KindDisplayModel();
            Category = new CategoryDisplayModel();
            Status = new StatusDisplayModel();

            // TODO Set ImageExtension value at Controller 
            Carrier.Import(entity.Carrier);
            Terminal.Import(entity.Terminal);
            Kind.Import(entity.Kind);
            Category.Import(entity.Category);
            Status.Import(entity.Status);
        }
    }
}
