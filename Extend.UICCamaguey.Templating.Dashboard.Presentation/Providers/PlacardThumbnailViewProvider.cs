namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.EventLiveStreamTemplateDescriptor.ID)
            {
                return new Views.EventLiveStreamPlacardThumbnailView();
            }

            return null;
        }
    }
}
