namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class LandscapeContextualTranslucentOverlapForImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("BFB19355-B4DF-4FAC-BAAF-9951943818BE");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen con Superposición Contextual Translúcida";

        public string Description => "Rellena la pantalla en horizontal con una imagen y la contextualiza con información superpuesta con un fondo de color con transparencia y marco seleccionado.";
    }
}
