using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitPosterVideoEventPromotionEventPlacardConfigurationPageFactory
    {
        public static Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                EventPoster = context.Poster.ToViewModel(),
                EventVideo = context.Video.ToViewModel()
            };
        }
    }
}
