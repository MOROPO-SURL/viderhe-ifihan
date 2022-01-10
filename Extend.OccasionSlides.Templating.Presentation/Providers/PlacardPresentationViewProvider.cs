namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTranslucentOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualFlatOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualFlatOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    UseOverlapShadown = context.UseOverlapShadown,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTrailOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
            }

            return null;
        }
    }
}

