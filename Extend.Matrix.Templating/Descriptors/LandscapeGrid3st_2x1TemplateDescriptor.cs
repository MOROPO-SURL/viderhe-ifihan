namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors
{
    public class LandscapeGrid3st_2x1TemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        // {0AA3AA52-8DE0-4B6D-B717-5B6787456905}
        public static System.Guid ID = new System.Guid(0xaa3aa52, 0x8de0, 0x4b6d, 0xb7, 0x17, 0x5b, 0x67, 0x87, 0x45, 0x69, 0x5);

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Matriz 2(dividido 1 arriba y 2 abajo)x1 horizontal";

        public string Description => "Muestra una matriz de una columna con dos filas (la de abajo dividida en dos segmentos) de carteles o guiones precreados en la plataforma horizontalmente.";
    }
}
