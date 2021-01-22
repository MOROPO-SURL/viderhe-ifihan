namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ConfigurePlayerPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string id;
        private string name;
        private string about;
        private Cloud.Api.Common.Models.ScreenplayDisplayModel screenplay;
        private Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlay;
        private string serializedOverlayContext;

        public ConfigurePlayerPageModel()
        {
            Screenplays = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.ScreenplayDisplayModel>();
            AvailableOverlays = new System.Collections.Generic.List<Extend.Common.Overlaying.Descriptors.IOverlayDescriptor>(Support.Extend.Overlaying.Providers.OverlayDescriptorProvider.Instance.GetDescriptors());

            AvailableOverlays.Insert(0, null);
        }

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel Screenplay
        {
            get => screenplay;
            set => SetProperty(ref screenplay, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.ScreenplayDisplayModel> Screenplays { get; set; }

        public Extend.Common.Overlaying.Descriptors.IOverlayDescriptor Overlay { get => overlay; set => SetProperty(ref overlay, value); }

        public string SerializedOverlayContext { get => serializedOverlayContext; set => SetProperty(ref serializedOverlayContext, value); }

        public System.Collections.Generic.List<Extend.Common.Overlaying.Descriptors.IOverlayDescriptor> AvailableOverlays { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Screenplays.Clear();

            Screenplays = null;

            Screenplay = null;
        }
    }
}
