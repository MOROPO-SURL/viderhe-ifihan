using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Extend.Overlaying.Providers;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ConfigurePlayerPageModel : FormPageModel
    {
        private string id;
        private string name;
        private string about;
        private ScreenplayDisplayModel screenplay;
        private Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlay;
        private string serializedOverlayContext;

        public ConfigurePlayerPageModel()
        {
            Screenplays = new System.Collections.ObjectModel.ObservableCollection<ScreenplayDisplayModel>();
            AvailableOverlays = new System.Collections.Generic.List<Extend.Common.Overlaying.Descriptors.IOverlayDescriptor>(OverlayDescriptorProvider.Instance.GetDescriptors());
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();

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

        public ScreenplayDisplayModel Screenplay
        {
            get => screenplay;
            set => SetProperty(ref screenplay, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<ScreenplayDisplayModel> Screenplays { get; set; }

        public Extend.Common.Overlaying.Descriptors.IOverlayDescriptor Overlay { get => overlay; set => SetProperty(ref overlay, value); }

        public string SerializedOverlayContext { get => serializedOverlayContext; set => SetProperty(ref serializedOverlayContext, value); }

        public System.Collections.Generic.List<Extend.Common.Overlaying.Descriptors.IOverlayDescriptor> AvailableOverlays { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Screenplays.Clear();

            Screenplays = null;

            Screenplay = null;
        }
    }
}
