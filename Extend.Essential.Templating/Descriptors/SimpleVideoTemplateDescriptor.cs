using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class SimpleVideoTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("BC45E572-CE72-46F2-BD39-0FCBFFC7A6C0");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Any;

        public string Name => "Video Simple";

        public string Description => "Reproduce un video referenciado desde la plataforma.";
    }
}