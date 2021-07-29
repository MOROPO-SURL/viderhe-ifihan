namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Descriptors
{
    public class LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("014FCE66-7BBD-472A-9955-EC01E93FA5FF");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Secuencia de Imágenes horizontal presentada por Imagen vertical";

        public string Description => "Muestra una imagen vertical presentando a una secuencia de imágenes a mostrarse de forma horizontal.";
    }
}