using SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitPicturePresentingPicturePlacardConfigurationPageModelFactory
    {
        public static Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PortraitPicturePresentingPicturePlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                PresenterImage = context.PresenterImage.ToViewModel(),
                PresenterSide = context.PresenterSide,
                PresentedImage = context.PresentedImage.ToViewModel(),
                PresentedImageCenteredAtPresentation = context.PresentedImageCenteredAtPresentation,
                PresentedImageZoomingEnabled = context.PresentedImageZoomingEnabled
            };
        }
    }
}
