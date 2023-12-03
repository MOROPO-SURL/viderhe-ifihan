using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Comparison
{
    public class TemplateEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Template>
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

        public bool Equals(Template x, Template y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Template obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
