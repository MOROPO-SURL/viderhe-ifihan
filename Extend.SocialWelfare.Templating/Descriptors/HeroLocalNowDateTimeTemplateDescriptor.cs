namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors
{
    public class HeroLocalNowDateTimeTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("E5B46F4C-6799-4501-8DF3-77F1E64CC62D");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Fecha y Hora Local Protagónica";

        public string Description => "Muestra con variantes de decoración la fecha y hora actual obtenida del dispositivo local acaparando la mayoría del espacio.";
    }
}