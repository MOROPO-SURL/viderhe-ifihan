namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeFramedTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("825472FB-DBA0-4F81-BFC5-E5D3997B79B9");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Información Enmarcada";

        public string Description => "Muestra el un título y una descripción enmarcada con marco y fondo configurable.";
    }
}
