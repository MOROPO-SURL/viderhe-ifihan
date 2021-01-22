namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static string ToImageResourceNameSufix(this Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            if (target == Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait) return "-portrait";

            return "-landscape";
        }

        public static bool SupportedByMainDisplayOrientation(this Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait:
                    return Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait;
                case Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape:
                    return Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation != Xamarin.Essentials.DisplayOrientation.Portrait;
                case Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any:
                default:
                    return true;
            }
        }
    }
}
