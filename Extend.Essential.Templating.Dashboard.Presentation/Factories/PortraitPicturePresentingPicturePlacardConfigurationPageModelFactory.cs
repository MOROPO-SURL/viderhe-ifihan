using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PortraitPicturePresentingPicturePlacardConfigurationPageModelFactory
    {
        public static Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel Build(PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PortraitPicturePresentingPicturePlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PortraitPicturePresentingPicturePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>(placardViewModel.Tags),
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
