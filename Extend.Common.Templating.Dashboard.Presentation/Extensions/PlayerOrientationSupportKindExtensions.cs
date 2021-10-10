namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static Enumerations.ConfigurationPlayerOrientationSupportKind ToConfiguration(this Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case Templating.Enumerations.PlayerOrientationSupportKind.Landscape:
                    return Enumerations.ConfigurationPlayerOrientationSupportKind.Landscape;

                case Templating.Enumerations.PlayerOrientationSupportKind.Portrait:
                    return Enumerations.ConfigurationPlayerOrientationSupportKind.Portrait;

                case Templating.Enumerations.PlayerOrientationSupportKind.Any:
                default:
                    return Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited;
            }
        }

        public static Templating.Enumerations.PlayerOrientationSupportKind? FromConfiguration(this Enumerations.ConfigurationPlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case Enumerations.ConfigurationPlayerOrientationSupportKind.Landscape:
                    return Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

                case Enumerations.ConfigurationPlayerOrientationSupportKind.Portrait:
                    return Templating.Enumerations.PlayerOrientationSupportKind.Portrait;

                case Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited:
                default:
                    return null;
            }
        }
    }
}
