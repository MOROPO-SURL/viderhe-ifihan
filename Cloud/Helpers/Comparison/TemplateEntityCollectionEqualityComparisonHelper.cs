namespace SmartSolucionesCuba.Videre.Cloud.Helpers.Comparison
{
    public class TemplateEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Persistence.Entities.Template>
    {
        private static TemplateEntityCollectionEqualityComparisonHelper instance;

        public static TemplateEntityCollectionEqualityComparisonHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemplateEntityCollectionEqualityComparisonHelper();
                }

                return instance;
            }
        }

        public bool Equals(Persistence.Entities.Template x, Persistence.Entities.Template y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Persistence.Entities.Template obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
