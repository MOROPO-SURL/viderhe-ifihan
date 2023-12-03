using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class PictureSlideSecuenceTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("88C0C0E5-C6DD-4E1C-B821-FACF619DD99D");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Any;

        public string Name => "Secuencia de Imágenes";

        public string Description => "Muestra una grupo de imágenes referenciadas desde la plataforma con la transición especificada.";
    }
}