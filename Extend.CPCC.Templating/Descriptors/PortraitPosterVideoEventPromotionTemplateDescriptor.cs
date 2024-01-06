namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Descriptors
{
    public class PortraitPosterVideoEventPromotionTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("3AE98930-ABD4-459D-8EAE-AD5CB28CC480");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Promoción Vertical de Evento con Poster y Video";

        public string Description => "Sin descripción en este momento.";
    }
}
