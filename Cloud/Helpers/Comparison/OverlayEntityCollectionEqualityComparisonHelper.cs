using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Comparison
{
    public class OverlayEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Overlay>
    {
        private static OverlayEntityCollectionEqualityComparisonHelper instance;

        public static OverlayEntityCollectionEqualityComparisonHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayEntityCollectionEqualityComparisonHelper();
                }

                return instance;
            }
        }

        public bool Equals(Overlay x, Overlay y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Overlay obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
