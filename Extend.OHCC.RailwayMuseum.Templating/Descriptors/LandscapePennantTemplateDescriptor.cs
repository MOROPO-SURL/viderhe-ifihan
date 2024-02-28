namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapePennantTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("57ABCEFA-538C-496D-8DA0-9051AB05331D");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Galladerte con Imagen de Fondo";

        public string Description => "Muestra el logotipo de identidad, un título y una descripción en un gallardete vertical con un estilo especificado y en el fondo una imagen.";
    }
}
