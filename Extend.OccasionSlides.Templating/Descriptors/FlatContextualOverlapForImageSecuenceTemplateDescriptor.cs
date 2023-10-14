namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class FlatContextualOverlapForImageSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {3CA00F49-56AB-4C88-AE6A-05D21791447F}
        public static System.Guid ID = new System.Guid(0x3ca00f49, 0x56ab, 0x4c88, 0xae, 0x6a, 0x5, 0xd2, 0x17, 0x91, 0x44, 0x7f);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Secuencia de Imágenes con Superposición Contextual Plana Simple";

        public string Description => "Muestra una secuencia de imagen y la contextualiza con información superpuesta con un fondo de color de sólido y marco seleccionado.";
    }
}
