namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class PicturePresentingVideoLandscapeTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("5172FEC6-78DB-4B26-BB61-14E0EB6C8342");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Video presentado por Imagen vertical";

        public string Description => "Muestra una imagen vertical presentando a un video, ambos referenciados desde la plataforma.";
    }
}