using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public static class TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.TranslucentContextualOverlapForImageSecuencePlacardContextModel>(placardViewModel.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            var result = new Models.Page.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                OverlapSize = context.OverlapSize,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                OverlapAlignment = context.OverlapAlignment,
                PictureSlidePresentationSecounds = System.Convert.ToInt32(context.PresentedPictureSlideSecuence.PicturePresentationSecounds)
            };

            foreach (var item in context.PresentedPictureSlideSecuence.Slides)
            {
                result.PresentedSlides.Add(new Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel
                {
                    Image = new Support.Presentation.Models.View.ImageViewModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                    LayoutMode = item.LayoutMode
                });
            }

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(item.ToViewModel());
                }
            }

            return result;
        }
    }
}
