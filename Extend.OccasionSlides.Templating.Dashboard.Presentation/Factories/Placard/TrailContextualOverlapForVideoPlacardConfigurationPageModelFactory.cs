using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public class TrailContextualOverlapForVideoPlacardConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.TrailContextualOverlapForVideoPlacardContextModel>(placardViewModel.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            var result = new Models.Page.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ContextedVideo = context.ContextedVideo.ToViewModel(),
                IsContextedVideoFramed = context.IsContextedVideoFramed,
                ContextedVideoCenteredAtPresentation = context.ContextedVideoCenteredAtPresentation,
                OverlapTrailMode = context.OverlapTrailMode,
                OverlapSize = context.OverlapSize,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                OverlapAlignment = context.OverlapAlignment
            };

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(new Models.View.ContentBlockCollectionItemViewModel { Target = item.ToViewModel() });
                }
            }

            return result;
        }
    }
}
