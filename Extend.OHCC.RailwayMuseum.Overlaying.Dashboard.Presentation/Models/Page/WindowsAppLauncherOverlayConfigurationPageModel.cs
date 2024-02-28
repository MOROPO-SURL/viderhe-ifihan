namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page
{
    public class WindowsAppLauncherOverlayConfigurationPageModel : Contract.AbstractDefaultCallToActionOverlayConfigurationPageModel
    {
        private string localPath;

        public WindowsAppLauncherOverlayConfigurationPageModel()
        {
            CallToActionMessage = "toca la pantalla para comenzar";
            CallToActionMessageFontSize = 30;
        }

        public string LocalPath { get => localPath; set => SetProperty(ref localPath, value); }
    }
}
