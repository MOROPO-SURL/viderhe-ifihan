namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Descriptors
{
    public class PortraitPicturePresentingPictureTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("A709675B-DABB-4A1E-B1A6-30A2C8691CF9");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Imagen vertical presentada por Imagen horizontal";

        public string Description => "Muestra una imagen horizontal presentando a otra vertical, ambas referenciadas desde la plataforma.";
    }
}
