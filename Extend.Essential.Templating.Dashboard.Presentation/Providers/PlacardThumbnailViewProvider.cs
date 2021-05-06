namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Providers
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

            if (model.Template.Id == Descriptors.LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                return new Views.LandscapePicturePresentingPicturePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                return new Views.LandscapePicturePresentingVideoPlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                return new Views.PortraitPicturePresentingPicturePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                return new Views.PortraitPicturePresentingVideoPlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
