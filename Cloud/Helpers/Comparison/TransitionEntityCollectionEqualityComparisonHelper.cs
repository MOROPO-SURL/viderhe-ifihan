using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Comparison
{
    public class TransitionEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Transition>
    {
        private static TransitionEntityCollectionEqualityComparisonHelper instance;

        public static TransitionEntityCollectionEqualityComparisonHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransitionEntityCollectionEqualityComparisonHelper();
                }

                return instance;
            }
        }

        public bool Equals(Transition x, Transition y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Transition obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
