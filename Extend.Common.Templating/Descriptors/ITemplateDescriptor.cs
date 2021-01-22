namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Descriptors
{
    public interface ITemplateDescriptor
    {
        System.Guid Id { get; }

        string Name { get; }

        Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport { get; }

        string Description { get; }
    }
}
