namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Descriptors
{
    public class LandscapeAnonimusHeroTemplateDescriptor : Common.Templating.Descriptors.ITemplateDescriptor
    {
        public static System.Guid ID = new System.Guid("C83B76A9-53B6-4D88-B18A-CAAD4D9F5338");

        public System.Guid Id => ID;

        public Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public string Name => "Historia de Vida";

        public string Description => "Muestra el logotipo de identidad y un perfil de una persona de interés museológico (nombre completo, reseña e imagen).";
    }
}
