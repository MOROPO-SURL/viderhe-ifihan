namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(model.SerializedContext);

                return new Views.PortraitPosterVideoEventPromotionPlacardView(new Models.View.PortraitPosterVideoEventPromotionPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PosterSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.Poster.Id)),
                    VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, context.Video.Id, context.Video.Extension).AbsoluteUri)
                });
            }

            return null;
        }
    }
}
