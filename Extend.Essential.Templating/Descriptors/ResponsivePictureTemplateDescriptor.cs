namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class ResponsivePictureTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("18C0C0E5-C6DD-4E1C-B821-FACF619DD99D");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Imagen Complementada";

        public string Description => "Muestra una imagen completa y sin transformaciones referenciada desde la plataforma rellenando los espacios no abarcados.";
    }
}
