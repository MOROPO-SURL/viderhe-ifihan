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
                OverlayHorizontalAlignment = context.OverlayHorizontalAlignment,
                Title = context.Title,
                TitleTextColor = Xamarin.Forms.Color.FromHex(context.TitleTextColor),
                TitleFontSize = context.TitleFontSize
            };

            context.InfoItems.ForEach(item => result.InfoItems.Add(item));

            return result;
        }
    }
}
