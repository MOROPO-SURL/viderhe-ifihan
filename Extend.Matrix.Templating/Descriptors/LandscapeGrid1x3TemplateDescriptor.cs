namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors
{
    public class LandscapeGrid1x3TemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {C6B86FAF-2583-4DA0-AE0D-FF1695F6B4FB}
        public static System.Guid ID = new System.Guid(0xc6b86faf, 0x2583, 0x4da0, 0xae, 0xd, 0xff, 0x16, 0x95, 0xf6, 0xb4, 0xfb);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Matriz 1x3 vertical";

        public string Description => "Muestra una matriz de una columna con tres filas de carteles o guiones precreados en la plataforma verticalmente.";
    }
}
