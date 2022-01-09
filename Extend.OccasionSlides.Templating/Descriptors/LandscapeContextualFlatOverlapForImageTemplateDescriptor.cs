namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class LandscapeContextualFlatOverlapForImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("5A2F1E9B-EC2C-46A4-92EC-2975EC6DFEEE");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen con Superposición Contextual Plana Simple";

        public string Description => "Rellena la pantalla en horizontal con una imagen y la contextualiza con información superpuesta con un fondo de color solido y marco seleccionado.";
    }
}