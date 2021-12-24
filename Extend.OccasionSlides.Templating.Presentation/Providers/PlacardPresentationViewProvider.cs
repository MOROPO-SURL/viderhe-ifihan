namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.LandscapeTranslucentOverlayContextedImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeTranslucentOverlayContextedImagePlacardContextModel>(model.SerializedContext);

                return new Views.LandscapeTranslucentOverlayContextedImagePlacardView(new Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    OverlaySize = context.OverlaySize,
                    OverlayShapeKind = context.OverlayShapeKind,
                    OverlayBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlayBackgroundColor),
                    OverlayHorizontalAlignment = context.OverlayHorizontalAlignment,
                    Title = context.Title,
                    TitleTextColor = Xamarin.Forms.Color.FromHex(context.TitleTextColor),
                    TitleFontSize = context.TitleFontSize,
                    InfoItems = context.InfoItems
                });
            }

            return null;
        }
    }
}

