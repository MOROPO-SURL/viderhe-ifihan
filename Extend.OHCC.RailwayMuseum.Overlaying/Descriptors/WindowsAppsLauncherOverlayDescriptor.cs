namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Descriptors
{
    public class WindowsAppsLauncherOverlayDescriptor : Common.Overlaying.Descriptors.IOverlayDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("B324FE13-7ECD-4878-BF28-BF35193B938E");

        public System.Guid Id => ID;

        public string Name => "Lanzador Multiple de Aplicaciones para Windows";

        public string Description => "Musetra un menú de aplicaciones locales para la plataforma Windows y que permite lanzar la seleccionada.";
    }
}
