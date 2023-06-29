namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class TranslucentContextualOverlapForVideoTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {2AFC0F5E-6601-4AF8-BCC2-A2D3493E0BB1}
        public static System.Guid ID = new System.Guid(0x2afc0f5e, 0x6601, 0x4af8, 0xbc, 0xc2, 0xa2, 0xd3, 0x49, 0x3e, 0xb, 0xb1);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Video con Superposición Contextual Translúcida";

        public string Description => "Rellena la pantalla con un video y la contextualiza con información superpuesta con un fondo de color con transparencia y marco seleccionado.";
    }
}
