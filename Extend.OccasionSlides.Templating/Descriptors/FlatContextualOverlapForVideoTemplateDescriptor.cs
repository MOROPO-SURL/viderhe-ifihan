namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class FlatContextualOverlapForVideoTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {1CC4C958-2E26-4EFB-AF2F-36A4BA01A5AB}
        public static System.Guid ID = new System.Guid(0x1cc4c958, 0x2e26, 0x4efb, 0xaf, 0x2f, 0x36, 0xa4, 0xba, 0x1, 0xa5, 0xab);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Video con Superposición Contextual Plana Simple";

        public string Description => "Rellena la pantalla con un video y la contextualiza con información superpuesta con un fondo de color sólido y marco seleccionado.";
    }
}