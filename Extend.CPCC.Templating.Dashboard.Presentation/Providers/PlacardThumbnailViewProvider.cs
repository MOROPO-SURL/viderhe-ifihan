namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                return new Views.PortraitPosterVideoEventPromotionEventPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
