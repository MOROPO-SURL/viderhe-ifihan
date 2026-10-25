using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Descriptors
{
    public interface ITemplateDescriptor
    {
        System.Guid Id { get; }

        string Name { get; }

        PlayerOrientationSupportKind PlayerOrientationSupport { get; }

        string Description { get; }
    }
}
