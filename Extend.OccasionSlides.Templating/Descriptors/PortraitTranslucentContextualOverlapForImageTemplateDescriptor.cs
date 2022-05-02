namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class PortraitTranslucentContextualOverlapForImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("C3F857EA-227D-44BA-90C1-39091E1E70C7");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Imagen con Superposición Contextual Translúcida";

        public string Description => "Rellena la pantalla en vertical con una imagen y la contextualiza con información superpuesta con un fondo de color con transparencia y marco seleccionado.";
    }
}
