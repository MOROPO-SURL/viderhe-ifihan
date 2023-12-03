namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors
{
    public class RssFeedCollageHeroTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("4D66C3C9-4DDD-485E-AA1B-C72069982B40");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Collage Heroico de Canal de Fuente RSS";

        public string Description => "Muestra un collage de 4 entradas de una fuente RSS enfatizando la última de estas y con encabezado relativo al canal.";
    }
}
