using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class CornerTileVideoPresentingVideoPlacardConfigurationPageModelFactory
    {
        public static Models.Page.CornerTileVideoPresentingVideoPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.CornerTileVideoPresentingVideoPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.CornerTileVideoPresentingVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.CornerTileVideoPresentingVideoPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                PresenterTileVideo = context.PresenterTileVideo.ToViewModel(),
                PresenterTileVideoPlayDelay = context.PresenterTileVideoPlayDelay,
                PresenterTileVideoScreenCorner = context.PresenterTileVideoScreenCorner,
                PresentedVideo = context.PresentedVideo.ToViewModel()
            };
        }
    }
}
