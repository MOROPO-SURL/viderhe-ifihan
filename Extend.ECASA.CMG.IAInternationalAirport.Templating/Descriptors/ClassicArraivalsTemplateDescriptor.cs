namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors
{
    public class ClassicArraivalsTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {4E2DCC18-C456-4B05-8975-89520F761BA8}
        public static System.Guid ID = new System.Guid(0x4e2dcc18, 0xc456, 0x4b05, 0x89, 0x75, 0x89, 0x52, 0xf, 0x76, 0x1b, 0xa8);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Próximos Arribos Estilo Clásico";

        public string Description => "Muestra el listado de los próximos arribos con una visualidad clásica en forma de tabla, configurable y con datos obtenidos desde el FIDS.";
    }
}
