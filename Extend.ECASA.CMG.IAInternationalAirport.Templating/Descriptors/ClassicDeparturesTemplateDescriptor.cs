namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors
{
    public class ClassicDeparturesTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {5675B0B4-325F-4F15-BB05-67E68573B053}
        public static System.Guid ID = new System.Guid(0x5675b0b4, 0x325f, 0x4f15, 0xbb, 0x5, 0x67, 0xe6, 0x85, 0x73, 0xb0, 0x53);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "FIDS Salidas (Clásico)";

        public string Description => "Muestra el listado de las próximas salidas con una visualidad clásica en forma de tabla, configurable y con datos obtenidos desde el FIDS.";
    }
}
