namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page
{
    public class WindowsAppsLauncherOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string title;
        private string firstLocalPath;
        private string secoundLocalPath;
        private string thirthLocalPath;
        private string callToActionMessage;
        private int callToActionMessageFontSize;

        public WindowsAppsLauncherOverlayConfigurationPageModel()
        {
            callToActionMessageFontSize = 12;
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string FirstLocalPath { get => firstLocalPath; set => SetProperty(ref firstLocalPath, value); }

        public string SecoundLocalPath { get => secoundLocalPath; set => SetProperty(ref secoundLocalPath, value); }

        public string ThirthLocalPath { get => thirthLocalPath; set => SetProperty(ref thirthLocalPath, value); }

        public string CallToActionMessage { get => callToActionMessage; set => SetProperty(ref callToActionMessage, value); }

        public int CallToActionMessageFontSize { get => callToActionMessageFontSize; set => SetProperty(ref callToActionMessageFontSize, value); }
    }
}
