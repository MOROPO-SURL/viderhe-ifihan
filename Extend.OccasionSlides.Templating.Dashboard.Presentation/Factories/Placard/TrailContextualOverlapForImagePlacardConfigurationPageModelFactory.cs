using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public static class TrailContextualOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.TrailContextualOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.TrailContextualOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.TrailContextualOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.TrailContextualOverlapForImagePlacardConfigurationPageModel
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
                OverlapAlignment = context.OverlapAlignment,
                Title = context.Title,
                TitleFontFamily = context.TitleFontFamily,
                TitleFontSize = context.TitleFontSize
            };

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(item.ToViewModel());
                }
            }

            return result;
        }
    }
}
