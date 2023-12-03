using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade
{
    public interface IPlacardPresentationViewProviderFacade
    {
        Common.Presentation.Views.BasePlacardPresentationView GetFor(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor);
    }
}
