namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Descriptors
{
    public class CoLabHackathonTeamTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("C32C4B89-56D2-4D0D-91B5-E8D1984AA339");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Equipo Hackathon Co-Lab";

        public string Description => "Sin definir por el momento.";
    }
}
