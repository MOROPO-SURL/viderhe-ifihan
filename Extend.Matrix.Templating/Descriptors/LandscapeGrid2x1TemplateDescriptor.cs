namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors
{
    public class LandscapeGrid2x1TemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {BFFE4380-69CB-4E54-87A3-7805F26D102E}
        public static System.Guid ID = new System.Guid(0xbffe4380, 0x69cb, 0x4e54, 0x87, 0xa3, 0x78, 0x5, 0xf2, 0x6d, 0x10, 0x2e);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Matriz 2x1 horizontal";

        public string Description => "Muestra una matriz de una columna con dos filas de carteles o guiones precreados en la plataforma verticalmente.";
    }
}
