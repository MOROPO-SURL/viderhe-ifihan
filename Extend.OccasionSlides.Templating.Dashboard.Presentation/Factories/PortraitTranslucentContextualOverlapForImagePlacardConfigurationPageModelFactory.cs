using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PortraitTranslucentContextualOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                OverlapVerticalAlignment = context.OverlapVerticalAlignment,
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
