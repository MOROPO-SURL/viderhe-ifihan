namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class PortraitFlatContextualOverlapForImageTemplateDescriptor// : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("787D2F5E-9815-445E-8BDF-3FFE3DEBB5BF");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

        public string Name => "Imagen con Superposición Contextual Plana";

        public string Description => "Rellena la pantalla en vertical con una imagen y la contextualiza con información superpuesta con un fondo de color sólido en un plano y marco seleccionado.";
    }
}
