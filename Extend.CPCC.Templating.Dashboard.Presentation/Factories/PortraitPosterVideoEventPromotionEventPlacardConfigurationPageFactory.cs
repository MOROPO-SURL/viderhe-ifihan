using MOROPO.VIDERHE.Extend.CPCC.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitPosterVideoEventPromotionEventPlacardConfigurationPageFactory
    {
        public static Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPosterVideoEventPromotionPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                EventPoster = context.Poster.ToViewModel(),
                EventVideo = context.Video.ToViewModel()
            };
        }
    }
}
