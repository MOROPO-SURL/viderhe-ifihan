namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CheckInDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CheckIn, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Number { get; set; }

        public OperationDisplayModel Operation { get; set; }

        public bool IsOpen { get; set; }

        public bool IsVIP { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public void Import(Persistence.Entities.CheckIn entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            IsOpen = entity.IsOpen;
            IsVIP = entity.IsVIP;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;

            Operation = new OperationDisplayModel();
            Operation.Import(entity.Operation);
        }
    }
}
