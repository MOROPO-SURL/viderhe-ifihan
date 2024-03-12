namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Descriptors
{
    public class EventLiveStreamTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("A9419619-2399-4F4B-83A7-4E7CC7C48546");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Transmisión en Vivo de Evento";

        public string Description => "Muestra una transmisión de video en vivo de un evento e información relativa a este.";
    }
}
