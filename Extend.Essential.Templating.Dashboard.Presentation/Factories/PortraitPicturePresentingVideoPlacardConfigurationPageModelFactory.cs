using SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitPicturePresentingVideoPlacardConfigurationPageModelFactory
    {
        public static Models.Page.PortraitPicturePresentingVideoPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitPicturePresentingVideoPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PortraitPicturePresentingVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PortraitPicturePresentingVideoPlacardConfigurationPageModel
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
