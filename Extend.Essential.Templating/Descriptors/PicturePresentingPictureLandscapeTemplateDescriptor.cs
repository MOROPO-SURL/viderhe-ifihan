namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class PicturePresentingPictureLandscapeTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("FA334577-0D4C-4366-9B68-A23D9D4AE004");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen presentada por Imagen";

        public string Description => "Muestra dos imágenes referenciadas desde la plataforma una presentadon a la otra.";
    }
}
