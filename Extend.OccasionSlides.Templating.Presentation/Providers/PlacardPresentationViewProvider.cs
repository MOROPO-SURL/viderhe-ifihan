namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTranslucentOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.LandscapeTranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeTranslucentContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.PortraitTranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitTranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.PortraitTranslucentContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapVerticalAlignment = context.OverlapVerticalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                return new Views.PortraitTranslucentContextualOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualFlatOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualFlatOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    UseOverlapShadown = context.UseOverlapShadown,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.PortraitFlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitFlatContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.PortraitFlatContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    UseOverlapShadown = context.UseOverlapShadown,
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapVerticalAlignment = context.OverlapVerticalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                return new Views.PortraitFlatContextualOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTrailOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (context.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
                {
                    return new Views.LeftLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.CenteredTraslucentIntroOverImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    HeadImageSource = context.HeadImage != null ? Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.HeadImage.Id)) : null,
                    BackgroundImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.BackgroundImage.Id)),
                    BackgroundImageZoomingEnabled = context.BackgroundImageZoomingEnabled,
                    OverlapOpacity = context.OverlapOpacity,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    ContentBoxPresentationKind = context.ContentBoxPresentationKind,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                return new Views.CenteredTraslucentIntroOverImagePlacardView(targetPlacardViewModel);
            }

            return null;
        }
    }
}

