namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Descriptors
{
    public class PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("B95B3064-2BDE-4237-80CF-9A31CC7536BA");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Secuencia de Imágenes vertical presentada por Imagen horizontal";

        public string Description => "Muestra una imagen horizontal presentando a una secuencia de imágenes a mostrarse de forma vertical.";
    }
}
