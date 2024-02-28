namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeFillFlyoutTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("2F3BA1AC-2476-4767-928D-68FCDD38436A");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Panel con Imagen de Fondo";

        public string Description => "Muestra el logotipo de identidad, un título y una descripción en un panel horizontal con un estilo especificado y en el fondo una imagen.";
    }
}
