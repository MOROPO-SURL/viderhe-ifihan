namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeFloatingFlyoutTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("B78BFD08-143F-40BA-AC5D-9AC825019581");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Panel Flotado con Imagen de Fondo";

        public string Description => "Muestra el logotipo de identidad, un título y una descripción en un panel horizontal y traslucido flotando con un estilo especificado y en el fondo una imagen.";
    }
}
