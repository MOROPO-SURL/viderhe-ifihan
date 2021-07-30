namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions
{
    public static class PlacardViewModelExtensions
    {
        public static bool SupportedByMainDisplayOrientation(this Models.View.PlacardViewModel target)
        {
            if (target.PlayerOrientationSupportKind != null) return IsDisplayOrientationCompatible(target.PlayerOrientationSupportKind.Value);

            return IsDisplayOrientationCompatible(target.Template.PlayerOrientationSupport);
        }

        private static bool IsDisplayOrientationCompatible(Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind supportedOrientationKind)
        {
            switch (supportedOrientationKind)
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
