namespace SmartSolucionesCuba.Videre.Support.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static string ToImageResourceNameSufix(this Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            if (target == Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait) return "-portrait";

            return "-landscape";
        }

        public static bool SupportedByMainDisplayOrientation(this Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            switch (target)
            {
                case Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait:
                    return Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait;
                case Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape:
                    return Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation != Xamarin.Essentials.DisplayOrientation.Portrait;
                case Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any:
                default:
                    return true;
            }
        }
    }
}
