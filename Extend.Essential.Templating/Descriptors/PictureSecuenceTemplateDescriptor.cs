namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class PictureSecuenceTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("88C0C0E5-C6DD-4E1C-B821-FACF619DD99D");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Secuencia de Imágenes";

        public string Description => "Muestra una grupo de imágenes referenciadas desde la plataforma con la transición especificada.";
    }
}
