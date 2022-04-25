namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Extensions
{
    public static class FeedItemExtensions
    {
        public static Models.View.RssFeedItemViewModel ToRssFeedItemViewModel(this CodeHollow.FeedReader.FeedItem target)
        {
            var result = new Models.View.RssFeedItemViewModel
            {
                Title = target.Title,
                Summary = target.Description,
                Published = target.PublishingDate
            };

            if (target.SpecificItem is CodeHollow.FeedReader.Feeds.MediaRssFeedItem)
            {
                var mediaRssFeedItem = target.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;

                if (mediaRssFeedItem.Enclosure != null && !string.IsNullOrEmpty(mediaRssFeedItem.Enclosure.Url))
                {
                    result.FeaturedImageSource = Xamarin.Forms.ImageSource.FromUri(new System.Uri(mediaRssFeedItem.Enclosure.Url));
                }

            }
            else if (target.SpecificItem is CodeHollow.FeedReader.Feeds.Rss092FeedItem)
            {
                var rss092FeedItem = target.SpecificItem as CodeHollow.FeedReader.Feeds.Rss092FeedItem;

                if (rss092FeedItem.Enclosure != null && !string.IsNullOrEmpty(rss092FeedItem.Enclosure.Url))
                {
                    result.FeaturedImageSource = Xamarin.Forms.ImageSource.FromUri(new System.Uri(rss092FeedItem.Enclosure.Url));
                }
            }
            else if (target.SpecificItem is CodeHollow.FeedReader.Feeds.Rss20FeedItem)
            {
                var rss20FeedItem = target.SpecificItem as CodeHollow.FeedReader.Feeds.Rss20FeedItem;

                if (rss20FeedItem.Enclosure != null && !string.IsNullOrEmpty(rss20FeedItem.Enclosure.Url))
                {
                    result.FeaturedImageSource = Xamarin.Forms.ImageSource.FromUri(new System.Uri(rss20FeedItem.Enclosure.Url));
                }
            }

            return result;
        }
    }
}
