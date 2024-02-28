using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class CornerTileVideoPresentingVideoPlacardViewModel : AbstractCornerTileVideoPresentingPlacardViewModel
    {
        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource PresentedVideoSource { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresentedVideoSource = null;
        }
    }
}
