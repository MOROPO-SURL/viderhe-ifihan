namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Descriptors
{
    public class AmbientalDashboardTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("4D4D1831-A130-4903-9F54-F9BA91379146");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Monitor Ambiental IoT";

        public string Description => "Descripción por definir.";
    }
}
