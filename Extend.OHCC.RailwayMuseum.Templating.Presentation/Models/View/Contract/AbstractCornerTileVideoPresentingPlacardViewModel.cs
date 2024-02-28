namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractCornerTileVideoPresentingPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource PresenterTileVideoSource { get; set; }

        public Enumerations.ScreenCorner PresenterTileVideoScreenCorner { get; set; }

        public System.TimeSpan PresenterTileVideoPlayDelay { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterTileVideoSource = null;
        }
    }
}
