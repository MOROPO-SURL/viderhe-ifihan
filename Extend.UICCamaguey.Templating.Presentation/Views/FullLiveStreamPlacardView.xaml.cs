using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Views
{
    public partial class FullLiveStreamPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public FullLiveStreamPlacardView(EventLiveStreamPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => VideoPlayerView;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        private void VideoPlayer_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            var videoPlayer = sender as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView;

            if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                videoPlayer.StatusUpdated -= VideoPlayer_StatusUpdated;

                EndPresentation();
            }
        }

        protected override void EndPresentation()
        {
            base.EndPresentation();

            VideoPlayerView.Dispose();
        }
    }
}