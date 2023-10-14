namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Descriptors
{
    public class TrailContextualOverlapForImageSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {D020EAE3-D0A9-4D33-9D71-2DAFB6D0AD33}
        public static System.Guid ID = new System.Guid(0xd020eae3, 0xd0a9, 0x4d33, 0x9d, 0x71, 0x2d, 0xaf, 0xb6, 0xd0, 0xad, 0x33);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Secuencia de Imágenes con Superposición Contextual Plana con Estela";

        public string Description => "Muestra una secuencia de imagen y la contextualiza con información superpuesta con un fondo de color sólido haciendo una estela y marco seleccionado.";
    }
}
