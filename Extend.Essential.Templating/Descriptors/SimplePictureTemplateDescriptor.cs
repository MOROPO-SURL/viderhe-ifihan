using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class SimplePictureTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("08C0C0E5-C6DD-4E1C-B821-FACF619DD99D");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Any;

        public string Name => "Imagen Simple";

        public string Description => "Muestra una imagen referenciada desde la plataforma.";
    }
}
