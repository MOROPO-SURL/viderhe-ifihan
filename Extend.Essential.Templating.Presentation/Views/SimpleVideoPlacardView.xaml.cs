using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Views
{
    public partial class SimpleVideoPlacardView : BaseTemplatedPlacardPresentationView
    {
        private AbstractTransition transition;

        public SimpleVideoPlacardView(Models.View.SimpleVideoPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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
            else if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                transition?.PerformMotion();

                transition = null;
            }
        }

        public override void StartShowInWhenReady(AbstractTransition transition)
        {
            if (VideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                base.StartShowInWhenReady(transition);

                return;
            }

            this.transition = transition;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (VideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                VideoPlayerView.StatusUpdated -= VideoPlayer_StatusUpdated;

                VideoPlayerView.Stop();
            }

            transition = null;
        }
    }
}