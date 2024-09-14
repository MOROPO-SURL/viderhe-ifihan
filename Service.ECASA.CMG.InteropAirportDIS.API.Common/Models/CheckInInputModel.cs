namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CheckInInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CheckIn, int>
    {
        public int Id { get; set; }

        public long OperationId { get; set; }

        public bool IsOpen { get; set; }

        public bool IsVIP { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public Persistence.Entities.CheckIn Export()
        {
            var entity = new Persistence.Entities.CheckIn { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CheckIn entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CheckIn entity)
        {
            entity.OperationId = OperationId;
            entity.IsOpen = IsOpen;
            entity.IsVIP = IsVIP;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;
        }
    }
}
