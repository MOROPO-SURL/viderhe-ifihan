namespace SmartSolucionesCuba.Videre.Cloud.Helpers.Comparison
{
    public class TransitionEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Persistence.Entities.Transition>
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

        public bool Equals(Persistence.Entities.Transition x, Persistence.Entities.Transition y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Persistence.Entities.Transition obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
