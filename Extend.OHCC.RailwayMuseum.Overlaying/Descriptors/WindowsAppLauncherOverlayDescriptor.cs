namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Descriptors
{
    public class WindowsAppLauncherOverlayDescriptor : Common.Overlaying.Descriptors.IOverlayDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("09096CD9-0E79-4350-B020-F8B338788E77");

        public System.Guid Id => ID;

        public string Name => "Lanzador de Aplicaciones para Windows";

        public string Description => "Inicia una aplicación local especificada para la plataforma Windows.";
    }
}
