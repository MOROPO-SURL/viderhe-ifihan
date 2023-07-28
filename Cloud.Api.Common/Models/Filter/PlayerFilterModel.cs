namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter
{
    public class PlayerFilterModel : MOROPO.SAPRESSC.Core.Persistence.Models.Filter.IEntityFilterModel<Persistence.Entities.Player, string>
    {
        public string Name { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Player, bool>> GetSelector()
        {
            return entity => true;
        }
    }
}
