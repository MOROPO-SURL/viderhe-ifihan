using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapePicturePresentingPicturePlacardConfigurationPageModelFactory
    {
        public static LandscapePicturePresentingPicturePlacardConfigurationPageModel Build(PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new LandscapePicturePresentingPicturePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapePicturePresentingPicturePlacardContextModel>(placardViewModel.SerializedContext);

            return new LandscapePicturePresentingPicturePlacardConfigurationPageModel
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
