namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractCornerTileVideoPresentingPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.VideoViewModel presenterTileVideo;
        private Templating.Presentation.Enumerations.ScreenCorner presenterTileVideoScreenCorner;
        private System.TimeSpan presenterTileVideoPlayDelay;

        public Support.Presentation.Models.View.VideoViewModel PresenterTileVideo { get => presenterTileVideo; set => SetProperty(ref presenterTileVideo, value); }

        public Templating.Presentation.Enumerations.ScreenCorner PresenterTileVideoScreenCorner { get => presenterTileVideoScreenCorner; set => SetProperty(ref presenterTileVideoScreenCorner, value); }

        public System.TimeSpan PresenterTileVideoPlayDelay { get => presenterTileVideoPlayDelay; set => SetProperty(ref presenterTileVideoPlayDelay, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterTileVideo = null;
        }
    }
}
