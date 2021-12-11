namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeVerticalStripeContextualizingImageTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("BE7FDBAB-4535-4349-92AF-DE7E40219E03");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Imagen con Banda Informativa";

        public string Description => "Muestra un banda con el logotipo de identidad, un título y una descripción contextualizando una imagen.";
    }
}
