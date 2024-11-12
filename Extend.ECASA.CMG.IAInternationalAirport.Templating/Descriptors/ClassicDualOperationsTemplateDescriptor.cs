namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors
{
    public class ClassicDualOperationsTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {CC3050CC-FC03-46A9-AEB6-5E9778B72060}
        public static System.Guid ID = new System.Guid(0xcc3050cc, 0xfc03, 0x46a9, 0xae, 0xb6, 0x5e, 0x97, 0x78, 0xb7, 0x20, 0x60);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "FIDS Combinado (Clásico)";

        public string Description => "Muestra el listado de las próximas llegadas y salidas con una visualidad clásica en forma de tabla, configurable y con datos obtenidos desde el FIDS.";
    }
}
