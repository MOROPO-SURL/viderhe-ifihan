using SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Views.TV
{
    public partial class IPTVChannelView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public IPTVChannelView(HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel model)
        {
            InitializeComponent();

            VideoPlayerView.Source = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(model.SourceSerialization);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            VideoPlayerView.Stop();

            VideoPlayerView.Source = null;

            VideoPlayerView.Dispose();
        }
    }
}