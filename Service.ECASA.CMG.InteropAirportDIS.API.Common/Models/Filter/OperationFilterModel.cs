namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter
{
    public class OperationFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Operation, long>
    {
        public Persistence.Enumerations.OperationKind Kind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Operation, bool>> GetSelector()
        {
            return entity => entity.KindId == Kind;
        }
    }
}
