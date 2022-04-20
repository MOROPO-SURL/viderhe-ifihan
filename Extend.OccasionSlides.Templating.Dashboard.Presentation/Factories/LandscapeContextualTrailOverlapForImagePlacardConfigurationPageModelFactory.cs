using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeContextualTrailOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
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
                TitleFontSize = context.TitleFontSize
            };

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(item);
                }
            }

            return result;
        }
    }
}
