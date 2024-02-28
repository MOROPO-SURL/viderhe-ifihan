using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class CornerTileVideoPresentingVideoPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition;

        public CornerTileVideoPresentingVideoPlacardView(CornerTileVideoPresentingVideoPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

        private void PresentedVideoPlayerView_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            if (PresentedVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                if (PresenterTileVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
                {
                    PresenterTileVideoPlayerView.StatusUpdated -= PresenterTileVideoPlayerView_StatusUpdated;

                    PresenterTileVideoPlayerView.Stop();
                }

                PresentedVideoPlayerView.StatusUpdated -= PresentedVideoPlayerView_StatusUpdated;

                EndPresentation();
            }
            else if (PresentedVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                transition?.PerformMotion();

                transition = null;
            }
        }

        private void PresenterTileVideoPlayerView_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            if (PresenterTileVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                PresenterTileVideoPlayerView.StatusUpdated -= PresenterTileVideoPlayerView_StatusUpdated;

                PlacardLayout.Children.Remove(PresenterTileVideoPlayerViewWrapper);

                PresenterTileVideoPlayerView.Dispose();
            }
        }

        public override void StartShowInWhenReady(Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition)
        {
            if (PresentedVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                base.StartShowInWhenReady(transition);

                return;
            }

            this.transition = transition;
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            PresenterTileVideoPlayerView.Play();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (PresenterTileVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                PresenterTileVideoPlayerView.StatusUpdated -= PresenterTileVideoPlayerView_StatusUpdated;

                PresenterTileVideoPlayerView.Stop();
            }

            if (PresentedVideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                PresentedVideoPlayerView.StatusUpdated -= PresentedVideoPlayerView_StatusUpdated;

                PresentedVideoPlayerView.Stop();
            }

            transition = null;
        }
    }
}