using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class RssFeedCollageHeroPlacardConfigurationPageModelFactory
    {
        public static RssFeedCollageHeroPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new RssFeedCollageHeroPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<RssFeedCollageHeroPlacardContextModel>(placardViewModel.SerializedContext);

            return new RssFeedCollageHeroPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                FeedUrl = context.FeedUrl,
                TintColor = Xamarin.Forms.Color.FromHex(context.TintColor)
            };
        }
    }
}
