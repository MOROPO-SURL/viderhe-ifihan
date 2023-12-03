namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors
{
    public class OverlayHeroCityTimeWeatherTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {F177D418-0C7E-4E58-AC97-C6744F492121}
        public static System.Guid ID = new System.Guid(0xf177d418, 0xc7e, 0x4e58, 0xac, 0x97, 0xc6, 0x74, 0x4f, 0x49, 0x21, 0x21);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Estado del Tiempo, Fecha y Hora de una Ciudad";

        public string Description => "Muestra estado del tiempo, la fecha y hora actual para una ciudad acaparando la mayoría del espacio y en superposición del fondo.";
    }
}
