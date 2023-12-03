using System.Linq;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Extensions
{
    public static class FeedItemExtensions
    {
        public static Models.View.RssFeedItemViewModel ToRssFeedItemViewModel(this CodeHollow.FeedReader.FeedItem target)
        {
            var result = new Models.View.RssFeedItemViewModel
            {
                Title = target.Title,
                Summary = System.Text.RegularExpressions.Regex.Replace(target.Description, "<[^>]*>", " ").Trim(),
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

            try
            {
                if (result.FeaturedImageSource == null)
                {
                    var descriptionDocument = System.Xml.Linq.XDocument.Parse(target.Description);

                    if (descriptionDocument.Descendants("img").Any())
                    {
                        var imgTag = descriptionDocument.Descendants("img").First();

                        var imageSrc = imgTag.Attribute("src").Value;

                        // TODO Pending for WebP image format suppor for UWP on FFImageLoading
                        if (Xamarin.Forms.Device.RuntimePlatform != Xamarin.Forms.Device.UWP)
                        {
                            result.FeaturedImageSource = Xamarin.Forms.ImageSource.FromUri(new System.Uri(imageSrc));
                        }
                        else if (!imageSrc.EndsWith(".webp"))
                        {
                            result.FeaturedImageSource = Xamarin.Forms.ImageSource.FromUri(new System.Uri(imageSrc));
                        }
                    }
                }
            }
            catch { }

            return result;
        }
    }
}
