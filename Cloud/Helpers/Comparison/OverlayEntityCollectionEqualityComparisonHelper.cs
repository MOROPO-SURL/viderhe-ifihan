namespace SmartSolucionesCuba.Viderhe.Cloud.Helpers.Comparison
{
    public class OverlayEntityCollectionEqualityComparisonHelper : System.Collections.Generic.IEqualityComparer<Persistence.Entities.Overlay>
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

        public bool Equals(Persistence.Entities.Overlay x, Persistence.Entities.Overlay y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Persistence.Entities.Overlay obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
