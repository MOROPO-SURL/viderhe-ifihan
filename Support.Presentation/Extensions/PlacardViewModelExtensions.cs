using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Extensions
{
    public static class PlacardViewModelExtensions
    {
        public static bool SupportedByTargetOrientation(this PlacardViewModel target, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            if (target == null) return false;

            if (target.PlayerOrientationSupportKind != null) return IsDisplayOrientationCompatible(target.PlayerOrientationSupportKind.Value, getOrientationFunction);

            if (target.Template == null) return false;

            return IsDisplayOrientationCompatible(target.Template.PlayerOrientationSupport, getOrientationFunction);
        }

        private static bool IsDisplayOrientationCompatible(PlayerOrientationSupportKind supportedOrientationKind, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            var orientation = getOrientationFunction.Invoke();

            switch (supportedOrientationKind)
            {
                case PlayerOrientationSupportKind.Portrait:
                    return orientation == Xamarin.Essentials.DisplayOrientation.Portrait;

                case PlayerOrientationSupportKind.Landscape:
                    return orientation != Xamarin.Essentials.DisplayOrientation.Portrait;

                case PlayerOrientationSupportKind.Any:
                default:
                    return true;
            }
        }
    }
}
