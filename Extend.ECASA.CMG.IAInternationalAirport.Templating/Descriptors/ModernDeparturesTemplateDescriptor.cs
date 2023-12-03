namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors
{
    public class ModernDeparturesTemplateDescriptor// : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {FFF8C4B1-3D68-40A5-A73C-603DE91F6BE4}
        public static System.Guid ID = new System.Guid(0xfff8c4b1, 0x3d68, 0x40a5, 0xa7, 0x3c, 0x60, 0x3d, 0xe9, 0x1f, 0x6b, 0xe4);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;

        public string Name => "Próximas Salidas Moderna";

        public string Description => "Muestra el listado de las próximas salidas con una visualidad moderna en forma de tarjetas, configurable y con datos obtenidos desde el FIDS.";
    }
}
