using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors
{
    public class PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor : ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("B95B3064-2BDE-4237-80CF-9A31CC7536BA");

        public System.Guid Id => ID;

        public PlayerOrientationSupportKind PlayerOrientationSupport => PlayerOrientationSupportKind.Portrait;

        public string Name => "Secuencia de Imágenes vertical presentada por Imagen horizontal";

        public string Description => "Muestra una imagen horizontal presentando a una secuencia de imágenes a mostrarse de forma vertical.";
    }
}
