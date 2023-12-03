namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors
{
    public class LandscapeGrid2x2TemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {BA1AC635-D9A0-4586-9A1A-98E87440E569}
        public static System.Guid ID = new System.Guid(0xba1ac635, 0xd9a0, 0x4586, 0x9a, 0x1a, 0x98, 0xe8, 0x74, 0x40, 0xe5, 0x69);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Matriz 2x2 vertical";

        public string Description => "Muestra una matriz de dos columnas con dos filas de carteles o guiones precreados en la plataforma verticalmente.";
    }
}
