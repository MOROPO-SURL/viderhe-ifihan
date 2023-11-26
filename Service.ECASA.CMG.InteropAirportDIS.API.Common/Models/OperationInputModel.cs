namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class OperationInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Operation, long>
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string CarrierId { get; set; }

        public int Flight { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Context { get; set; }

        public System.DateTime Date { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Gate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? TerminalId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Persistence.Enumerations.OperationKind? KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? StatusId { get; set; }

        public Persistence.Entities.Operation Export()
        {
            var entity = new Persistence.Entities.Operation
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Operation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Operation entity)
        {
            entity.CarrierId = CarrierId;
            entity.CategoryId = CategoryId;
            entity.StatusId = StatusId;
            entity.TerminalId = TerminalId;
            entity.Date = Date;
            entity.Gate = Gate;
            entity.KindId = KindId;
            entity.Flight = Flight;
            entity.Context = Context;
        }
    }
}
