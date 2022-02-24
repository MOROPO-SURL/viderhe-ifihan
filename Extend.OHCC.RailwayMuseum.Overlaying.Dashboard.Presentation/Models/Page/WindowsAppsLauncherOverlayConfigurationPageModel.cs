namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page
{
    public class WindowsAppsLauncherOverlayConfigurationPageModel : Contract.AbstractDefaultCallToActionOverlayConfigurationPageModel
    {
        private string title;
        private string firstLocalPath;
        private string secoundLocalPath;
        private string thirthLocalPath;

        public WindowsAppsLauncherOverlayConfigurationPageModel()
        {
            CallToActionMessage = "toca la pantalla para comenzar";
            CallToActionMessageFontSize = 30;
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string FirstLocalPath { get => firstLocalPath; set => SetProperty(ref firstLocalPath, value); }

        public string SecoundLocalPath { get => secoundLocalPath; set => SetProperty(ref secoundLocalPath, value); }

        public string ThirthLocalPath { get => thirthLocalPath; set => SetProperty(ref thirthLocalPath, value); }
    }
}
