namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class LandscapeTranslucentContextualOverlapForImageSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("2AFABF13-7976-4C71-9483-9E805AB9A0A1");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen con Superposición Contextual Translúcida";

        public string Description => "Rellena la pantalla en horizontal con una imagen y la contextualiza con información superpuesta con un fondo de color con transparencia y marco seleccionado.";
    }
}
