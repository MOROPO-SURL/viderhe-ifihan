namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class RssFeedCollageHeroPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string feedUrl;
        private Xamarin.Forms.Color tintColor;

        public RssFeedCollageHeroPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            tintColor = Xamarin.Forms.Color.Red;
        }

        public Xamarin.Forms.Color TintColor { get => tintColor; set => SetProperty(ref tintColor, value); }
        
        public string FeedUrl { get => feedUrl; set => SetProperty(ref feedUrl, value); }
    }
}
