namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public abstract class AbstractPhotoEventDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public abstract System.Guid Id { get; }
        public abstract string Name { get; }
        public abstract Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport { get; }
        public abstract string Description { get; }
    }
}
