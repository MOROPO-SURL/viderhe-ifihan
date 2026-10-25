using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("014FCE66-7BBD-472A-9955-EC01E93FA5FF");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Landscape;

        public string Name => "Secuencia de Imágenes horizontal presentada por Imagen vertical";

        public string Description => "Muestra una imagen vertical presentando a una secuencia de imágenes a mostrarse de forma horizontal.";
    }
}