namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CheckInInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CheckIn, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Number { get; set; }

        public long DepartureOperationId { get; set; }

        public long? ArrivalOperationId { get; set; }

        public bool IsOpen { get; set; }

        public bool IsVIP { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public Persistence.Entities.CheckIn Export()
        {
            var entity = new Persistence.Entities.CheckIn();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CheckIn entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CheckIn entity)
        {
            entity.Number = Number;
            entity.DepartureOperationId = DepartureOperationId;
            entity.ArrivalOperationId = ArrivalOperationId;
            entity.IsOpen = IsOpen;
            entity.IsVIP = IsVIP;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;

            if (entity.DepartureOperationId != DepartureOperationId)
            {
                entity.DepartureOperation = null;
                entity.DepartureOperationId = DepartureOperationId;
            }

            if (entity.ArrivalOperationId != ArrivalOperationId)
            {
                entity.ArrivalOperation = null;
                entity.ArrivalOperationId = ArrivalOperationId;
            }
        }
    }
}
