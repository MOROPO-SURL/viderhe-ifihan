using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeContextualTranslucentOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                OverlapSize = context.OverlapSize,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                OverlapHorizontalAlignment = context.OverlapHorizontalAlignment,
                Title = context.Title,
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
