using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class PortraitPicturePresentingPictureTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("A709675B-DABB-4A1E-B1A6-30A2C8691CF9");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Portrait;

        public string Name => "Imagen vertical presentada por Imagen horizontal";

        public string Description => "Muestra una imagen horizontal presentando a otra vertical, ambas referenciadas desde la plataforma.";
    }
}
