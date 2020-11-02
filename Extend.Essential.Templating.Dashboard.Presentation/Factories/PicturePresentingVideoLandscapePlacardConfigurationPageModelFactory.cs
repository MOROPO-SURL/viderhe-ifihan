using SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public class PicturePresentingVideoLandscapePlacardConfigurationPageModelFactory
    {
        public static Models.Page.PicturePresentingVideoLandscapePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PicturePresentingVideoLandscapePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PicturePresentingVideoLandscapePlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PicturePresentingVideoLandscapePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                PresenterImage = context.PresenterImage.ToViewModel(),
                PresenterSide = context.PresenterSide,
                PresentedVideo = context.PresentedVideo.ToViewModel(),
                PresentedVideoCenteredAtPresentation = context.PresentedVideoCenteredAtPresentation
            };
        }
    }
}
