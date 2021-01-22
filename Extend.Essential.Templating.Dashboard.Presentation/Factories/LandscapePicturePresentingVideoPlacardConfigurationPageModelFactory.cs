using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public class LandscapePicturePresentingVideoPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapePicturePresentingVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                PresenterImage = context.PresenterImage.ToViewModel(),
                PresenterSide = context.PresenterSide,
                PresentedVideo = context.PresentedVideo.ToViewModel(),
                PresentedVideoCenteredAtPresentation = context.PresentedVideoCenteredAtPresentation
            };
        }
    }
}
