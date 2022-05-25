namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class RssFeedCollageHeroPlacardConfigurationPageModelFactory
    {
        public static Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.RssFeedCollageHeroContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.RssFeedCollageHeroPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                FeedUrl = context.FeedUrl,
                TintColor = Xamarin.Forms.Color.FromHex(context.TintColor)
            };
        }
    }
}
