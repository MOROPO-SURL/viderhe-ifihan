namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class LandscapePicturePresentingPictureTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("FA334577-0D4C-4366-9B68-A23D9D4AE004");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen horizontal presentada por Imagen vertical";

        public string Description => "Muestra una imagen vertical presentando a otra horizontal, ambas referenciadas desde la plataforma.";
    }
}
