using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public static class TranslucentContextualOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.TranslucentContextualOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                OverlapSize = context.OverlapSize,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                OverlapAlignment = context.OverlapAlignment
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
