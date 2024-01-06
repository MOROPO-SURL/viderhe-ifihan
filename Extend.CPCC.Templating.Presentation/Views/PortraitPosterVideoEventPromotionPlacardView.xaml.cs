using MOROPO.VIDERHE.Extend.CPCC.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Presentation.Views
{
    public partial class PortraitPosterVideoEventPromotionPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitPosterVideoEventPromotionPlacardView(PortraitPosterVideoEventPromotionPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

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

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            EventVideo.Play();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (EventVideo.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                EventVideo.StatusUpdated -= VideoPlayer_StatusUpdated;

                EventVideo.Stop();
            }
        }
    }
}