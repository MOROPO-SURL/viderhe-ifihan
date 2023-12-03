namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors
{
    public class TrailContextualOverlapForVideoTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {8720E8C5-80AA-49E2-AF95-264DAEB3A91A}
        public static System.Guid ID = new System.Guid(0x8720e8c5, 0x80aa, 0x49e2, 0xaf, 0x95, 0x26, 0x4d, 0xae, 0xb3, 0xa9, 0x1a);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Video con Superposición Contextual Plana con Estela";

        public string Description => "Rellena la pantalla con un video y la contextualiza con información superpuesta con un fondo de color sólido haciendo una estela y marco seleccionado.";
    }
}
