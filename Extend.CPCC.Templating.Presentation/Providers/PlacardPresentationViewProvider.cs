using MOROPO.VIDERHE.Extend.CPCC.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.CPCC.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id == PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPosterVideoEventPromotionPlacardContextModel>(model.SerializedContext);

                return new Views.PortraitPosterVideoEventPromotionPlacardView(new Models.View.PortraitPosterVideoEventPromotionPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PosterSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.Poster.Id)),
                    VideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.Video.Id, context.Video.Extension).AbsoluteUri)
                }, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}
