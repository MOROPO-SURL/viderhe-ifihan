namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class RssFeedCollageHeroPlacardConfigurationPageModelFactory
    {
        public static Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.RssFeedCollageHeroPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                FeedUrl = context.FeedUrl,
                TintColor = Xamarin.Forms.Color.FromHex(context.TintColor)
            };
        }
    }
}
