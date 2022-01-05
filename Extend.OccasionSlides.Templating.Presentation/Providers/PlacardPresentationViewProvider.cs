namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.LandscapeTranslucentOverlayContextedImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeTranslucentOverlayContextedImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    OverlaySize = context.OverlaySize,
                    OverlayShapeKind = context.OverlayShapeKind,
                    OverlayBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlayBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlayHorizontalAlignment = context.OverlayHorizontalAlignment,
                    Title = context.Title,
                    TitleFontSize = context.TitleFontSize,
                    InfoBlocks = context.InfoBlocks
                };

                if (context.OverlayHorizontalAlignment == Enumerations.MediaContextOverlayHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeTranslucentOverlayContextedImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeTranslucentOverlayContextedImagePlacardView(targetPlacardViewModel);
            }

            return null;
        }
    }
}

