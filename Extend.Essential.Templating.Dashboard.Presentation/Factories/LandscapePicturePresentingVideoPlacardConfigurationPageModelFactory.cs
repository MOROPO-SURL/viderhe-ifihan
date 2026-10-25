using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public class LandscapePicturePresentingVideoPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel Build(PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapePicturePresentingVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapePicturePresentingVideoPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>(placardViewModel.Tags),
                PresenterImage = context.PresenterImage.ToViewModel(),
                PresenterSide = context.PresenterSide,
                PresentedVideo = context.PresentedVideo.ToViewModel(),
                PresentedVideoCenteredAtPresentation = context.PresentedVideoCenteredAtPresentation
            };
        }
    }
}
