namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page
{
    public class WindowsAppLauncherOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string localPath;
        private string callToActionMessage;
        private int callToActionMessageFontSize;

        public WindowsAppLauncherOverlayConfigurationPageModel()
        {
            callToActionMessageFontSize = 12;
        }

        public string LocalPath { get => localPath; set => SetProperty(ref localPath, value); }

        public string CallToActionMessage { get => callToActionMessage; set => SetProperty(ref callToActionMessage, value); }

        public int CallToActionMessageFontSize { get => callToActionMessageFontSize; set => SetProperty(ref callToActionMessageFontSize, value); }
    }
}
