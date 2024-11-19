namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter
{
    public class CheckInFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.CheckIn, System.Guid>
    {
        public int Number { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.CheckIn, bool>> GetSelector()
        {
            return entity => entity.Number == Number;
        }
    }
}
