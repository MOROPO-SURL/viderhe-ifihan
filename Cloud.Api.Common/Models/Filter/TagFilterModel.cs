namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter
{
    public class TagFilterModel : MOROPO.SAPRESSC.Core.Persistence.Models.Filter.IEntityFilterModel<Persistence.Entities.Tag, System.Guid>
    {
        public Persistence.Enumerations.TagGroup Group { get; set; }

        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Tag, bool>> GetSelector()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return entity => entity.Group == Group;
            }

            return entity => entity.Group == Group && entity.Name.Contains(Name);
        }
    }
}
