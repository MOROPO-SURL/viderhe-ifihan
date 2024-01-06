namespace MOROPO.VIDERHE.Extend.Common.Descriptors
{
    public interface IExtensionDescriptor
    {
        System.Guid Id { get; }

        string Name { get; }

        string Description { get; }
    }
}
