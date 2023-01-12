namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            if (model.Template.Id == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(model.SerializedContext);

                return new Views.PortraitPosterVideoEventPromotionPlacardView(new Models.View.PortraitPosterVideoEventPromotionPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PosterSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.Poster.Id)),
                    VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.Video.Id, context.Video.Extension).AbsoluteUri)
                });
            }

            return null;
        }
    }
}
