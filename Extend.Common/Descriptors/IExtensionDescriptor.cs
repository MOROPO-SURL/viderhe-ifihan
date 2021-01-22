namespace SmartSolucionesCuba.Viderhe.Extend.Common.Descriptors
{
    public interface IExtensionDescriptor
    {
        System.Guid Id { get; }

        string Name { get; }

        string Description { get; }
    }
}
