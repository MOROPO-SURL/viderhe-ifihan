using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Helpers.Facade
{
    public interface IPlacardThumbnailViewProvisioningHelperFacade
    {
        Xamarin.Forms.ContentView GetPlacardThumnailView(PlacardViewModel model);
    }
}
