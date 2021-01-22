namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Descriptors
{
    public class PortraitPicturePresentingVideoTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("D95695DB-C210-4E6C-92DA-344354D0731E");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Video presentado por Imagen horizontal";

        public string Description => "Muestra una imagen horizontal presentando a un video, ambos referenciados desde la plataforma.";
    }
}
