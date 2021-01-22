namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.View
{
    public class PlayerViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private bool isConnected;
        private int audioLevel;
        private bool audioEnabled;

        public string Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel Screenplay { get; set; }

        public bool IsConnected { get => isConnected; set => SetProperty(ref isConnected, value); }

        public int AudioLevel { get => audioLevel; set => SetProperty(ref audioLevel, value); }

        public bool AudioEnabled { get => audioEnabled; set => SetProperty(ref audioEnabled, value); }

        public System.Guid? OverlayId { get; set; }

        public string SerializedOverlayContext { get; set; }
    }
}
