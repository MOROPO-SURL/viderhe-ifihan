namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class TrailContextualOverlapForImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("5F1E38D6-DABB-4B90-8845-C07E8F5DD9E0");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen con Superposición Contextual Plana con Estela";

        public string Description => "Rellena la pantalla con una imagen y la contextualiza con información superpuesta con un fondo de color sólido haciendo una estela y marco seleccionado.";
    }
}
