using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.TranslucentContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapAlignment = context.OverlapAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.PortraitTranslucentContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.LeftLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.TranslucentContextualOverlapForImageSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    OverlapAlignment = context.OverlapAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.PortraitTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.FlatContextualOverlapForImagePlacardViewModel
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
                    OverlapAlignment = context.OverlapAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.PortraitFlatContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.LeftLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

                var targetPlacardViewModel = new Models.View.TrailContextualOverlapForImagePlacardViewModel
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
                    OverlapAlignment = context.OverlapAlignment,
                    Title = context.Title,
                    TitleFontFamily = context.TitleFontFamily,
                    TitleFontSize = context.TitleFontSize,
                    ContentBlocks = context.ContentBlocks
                };

                if (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.PortraitTrailContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.LeftLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.RightLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(model.SerializedContext);

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

