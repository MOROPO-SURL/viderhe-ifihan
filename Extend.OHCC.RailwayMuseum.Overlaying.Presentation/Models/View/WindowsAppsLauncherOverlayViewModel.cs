namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Models.View
{
    public class WindowsAppsLauncherOverlayViewModel : Context.Contract.AbstractDefaultCallToActionOverlayContextModel
    {
        public string Title { get; set; }

        public WindowsAppLaunchViewModel[] Launchs { get; set; }
    }
}
