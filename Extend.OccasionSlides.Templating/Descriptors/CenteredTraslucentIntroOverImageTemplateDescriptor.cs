namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class CenteredTraslucentIntroOverImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("FA754670-FD62-4E36-B6C7-400B6689F00C");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Intro centrado translúcido sobre Imagen";

        public string Description => "Rellena la pantalla con una imagen y la contextualiza con información superpuesta con un fondo de color con transparencia centrada en la pantalla.";
    }
}
