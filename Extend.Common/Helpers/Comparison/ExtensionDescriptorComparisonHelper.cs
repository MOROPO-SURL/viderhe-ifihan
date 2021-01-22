namespace SmartSolucionesCuba.Viderhe.Extend.Common.Helpers.Comparison
{
    public class ExtensionDescriptorComparisonHelper : System.Collections.Generic.IEqualityComparer<Descriptors.IExtensionDescriptor>
    {
        public bool Equals(Descriptors.IExtensionDescriptor x, Descriptors.IExtensionDescriptor y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Descriptors.IExtensionDescriptor obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
