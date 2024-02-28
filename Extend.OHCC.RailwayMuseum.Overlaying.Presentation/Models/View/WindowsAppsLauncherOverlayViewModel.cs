using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Models.Context.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Models.View
{
    public class WindowsAppsLauncherOverlayViewModel : AbstractDefaultCallToActionOverlayContextModel
    {
        public string Title { get; set; }

        public WindowsAppLaunchViewModel[] Launchs { get; set; }
    }
}
