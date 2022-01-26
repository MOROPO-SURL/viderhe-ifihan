namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeCrossStripeTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("BE7FDBAB-4535-4349-92AF-DE7E40219E03");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Cinta Transversal con Imagen de Fondo";

        public string Description => "Muestra el logotipo de identidad, un título y una descripción en una cinta transversal y en el fondo una imagen.";
    }
}
