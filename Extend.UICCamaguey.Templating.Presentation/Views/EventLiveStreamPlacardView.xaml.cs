namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Views
{
    public partial class EventLiveStreamPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public EventLiveStreamPlacardView(Models.View.EventLiveStreamPlacardViewModel model)
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
            var videoPlayer = sender as XFToolKit.Presentation.Views.Rendered.VideoPlayerView;

            if (videoPlayer.Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
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