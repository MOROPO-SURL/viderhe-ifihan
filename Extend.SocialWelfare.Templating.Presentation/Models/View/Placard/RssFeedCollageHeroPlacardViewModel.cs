namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard
{
    public class RssFeedCollageHeroPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        private bool isBusy;
        private string feedTitle;
        private string feedDescription;
        private string feedLastUpdatedDateString;
        private Xamarin.Forms.ImageSource feedImageSource;
        private RssFeedItemViewModel heroFeedItem;
        private RssFeedItemViewModel secoundFeedItem;
        private RssFeedItemViewModel thirdFeedItem;
        private RssFeedItemViewModel fourthFeedItem;

        public Xamarin.Forms.Color TintColor { get; set; }

        public string FeedTitle { get => feedTitle; set => SetProperty(ref feedTitle, value); }

        public string FeedDescription { get => feedDescription; set => SetProperty(ref feedDescription, value); }

        public string FeedLastUpdatedDateString { get => feedLastUpdatedDateString; set => SetProperty(ref feedLastUpdatedDateString, value); }

        public Xamarin.Forms.ImageSource FeedImageSource { get => feedImageSource; set => SetProperty(ref feedImageSource, value); }

        public RssFeedItemViewModel HeroFeedItem { get => heroFeedItem; set => SetProperty(ref heroFeedItem, value); }

        public RssFeedItemViewModel SecoundFeedItem { get => secoundFeedItem; set => SetProperty(ref secoundFeedItem, value); }

        public RssFeedItemViewModel ThirdFeedItem { get => thirdFeedItem; set => SetProperty(ref thirdFeedItem, value); }

        public RssFeedItemViewModel FourthFeedItem { get => fourthFeedItem; set => SetProperty(ref fourthFeedItem, value); }

        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }
    }
}
