using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractCornerTileVideoPresentingPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.VideoViewModel presenterTileVideo;
        private ScreenCorner presenterTileVideoScreenCorner;
        private System.TimeSpan presenterTileVideoPlayDelay;

        public AbstractCornerTileVideoPresentingPlacardConfigurationPageModel()
        {
            PresenterTileVideoScreenCorner = ScreenCorner.BottonRight;

            AvailablePresenterTileVideoScreenCorners = new ScreenCorner[] 
            {
                ScreenCorner.TopLeft,
                ScreenCorner.TopRight,
                ScreenCorner.BottomLeft,
                ScreenCorner.BottonRight 
            };
        }

        public Support.Presentation.Models.View.VideoViewModel PresenterTileVideo { get => presenterTileVideo; set => SetProperty(ref presenterTileVideo, value); }

        public ScreenCorner PresenterTileVideoScreenCorner { get => presenterTileVideoScreenCorner; set => SetProperty(ref presenterTileVideoScreenCorner, value); }

        public ScreenCorner[] AvailablePresenterTileVideoScreenCorners { get; private set; }

        public System.TimeSpan PresenterTileVideoPlayDelay { get => presenterTileVideoPlayDelay; set => SetProperty(ref presenterTileVideoPlayDelay, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterTileVideo = null;
        }
    }
}
