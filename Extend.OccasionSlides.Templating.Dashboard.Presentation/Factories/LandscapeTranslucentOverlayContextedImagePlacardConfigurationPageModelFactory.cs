using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeTranslucentOverlayContextedImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                OverlaySize = context.OverlaySize,
                OverlayShapeKind = context.OverlayShapeKind,
                OverlayBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlayBackgroundColor),
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                OverlayHorizontalAlignment = context.OverlayHorizontalAlignment,
                Title = context.Title,
                TitleFontSize = context.TitleFontSize
            };

            if (context.InfoBlocks != null)
            {
                foreach (var item in context.InfoBlocks)
                {
                    result.InfoBlocks.Add(item);
                }
            }

            return result;
        }
    }
}
