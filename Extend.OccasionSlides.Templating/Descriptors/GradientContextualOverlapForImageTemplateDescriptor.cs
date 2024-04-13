namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors
{
    public class GradientContextualOverlapForImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {84F9E7B2-EC2C-45DC-98C9-C2B61C141098}
        public static System.Guid ID = new System.Guid(0x84f9e7b2, 0xec2c, 0x45dc, 0x98, 0xc9, 0xc2, 0xb6, 0x1c, 0x14, 0x10, 0x98);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Imagen con Superposición Contextual en Gradiente";

        public string Description => "Rellena la pantalla con una imagen y la contextualiza con información superpuesta con un gradiente como fondo a partir del color seleccionado.";
    }
}
