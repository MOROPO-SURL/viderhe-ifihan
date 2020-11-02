namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.PictureSecuenceTemplateDescriptor.ID)
            {
                return new Views.PictureSecuencePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.SimpleVideoTemplateDescriptor.ID)
            {
                return new Views.SimpleVideoPlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.SimplePictureTemplateDescriptor.ID)
            {
                return new Views.SimplePicturePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.ResponsivePictureTemplateDescriptor.ID)
            {
                return new Views.ResponsivePicturePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.PicturePresentingPictureLandscapeTemplateDescriptor.ID)
            {
                return new Views.PicturePresentingPictureLandscapePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.PicturePresentingVideoLandscapeTemplateDescriptor.ID)
            {
                return new Views.PicturePresentingVideoLandscapePlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
