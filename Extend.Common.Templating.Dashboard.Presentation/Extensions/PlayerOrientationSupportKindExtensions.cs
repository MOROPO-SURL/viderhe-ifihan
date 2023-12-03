using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static ConfigurationPlayerOrientationSupportKind ToConfiguration(this PlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case PlayerOrientationSupportKind.Landscape:
                    return ConfigurationPlayerOrientationSupportKind.Landscape;

                case PlayerOrientationSupportKind.Portrait:
                    return ConfigurationPlayerOrientationSupportKind.Portrait;

                case PlayerOrientationSupportKind.Any:
                default:
                    return ConfigurationPlayerOrientationSupportKind.Inherited;
            }
        }

        public static PlayerOrientationSupportKind? FromConfiguration(this ConfigurationPlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case ConfigurationPlayerOrientationSupportKind.Landscape:
                    return PlayerOrientationSupportKind.Landscape;

                case ConfigurationPlayerOrientationSupportKind.Portrait:
                    return PlayerOrientationSupportKind.Portrait;

                case ConfigurationPlayerOrientationSupportKind.Inherited:
                default:
                    return null;
            }
        }
    }
}
