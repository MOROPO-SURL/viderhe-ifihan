using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeAnonimusHeroPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeAnonimusHeroPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeAnonimusHeroPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeAnonimusHeroPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapeAnonimusHeroPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                HeroImage = context.HeroImage.ToViewModel(),
                Header = context.Header,
                HeaderFontSize = context.HeaderFontSize,
                Content = context.Content,
                ContentFontSize = context.ContentFontSize,
                BackgroundMode = context.BackgroundMode
            };
        }
    }
}
