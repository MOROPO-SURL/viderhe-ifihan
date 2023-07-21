namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Views
{
    public partial class PlacardComplementVideoView : XFToolKit.Mvvm.Views.ContentView
    {
        private Common.Presentation.Views.BasePlacardPresentationView placardPresentationView;

        public PlacardComplementVideoView(Common.Presentation.Views.BasePlacardPresentationView placardPresentationView, Templating.Models.Context.VideoComplementContextModel model)
        {
            InitializeComponent();

            switch (model.Position)
            {
                case Enumerations.VideoComplementPosition.TopLeft:
                case Enumerations.VideoComplementPosition.BottomLeft:
                    VideoPlayerViewLayout.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;

                    break;

                case Enumerations.VideoComplementPosition.TopRight:
                case Enumerations.VideoComplementPosition.BottomRight:
                default:
                    VideoPlayerViewLayout.HorizontalOptions = Xamarin.Forms.LayoutOptions.End;

                    break;
            }

            switch (model.Position)
            {
                case Enumerations.VideoComplementPosition.TopLeft:
                case Enumerations.VideoComplementPosition.TopRight:
                    VideoPlayerViewLayout.VerticalOptions = Xamarin.Forms.LayoutOptions.Start;

                    break;

                case Enumerations.VideoComplementPosition.BottomLeft:
                case Enumerations.VideoComplementPosition.BottomRight:
                default:
                    VideoPlayerViewLayout.VerticalOptions = Xamarin.Forms.LayoutOptions.End;

                    break;
            }

            IsVisible = false;

            VideoPlayerView.WidthRequest = VideoPlayerView.HeightRequest = placardPresentationView.Width * 0.15;

            this.placardPresentationView = placardPresentationView;

            VideoPlayerView.StatusUpdated += VideoPlayerView_StatusUpdated;

            VideoPlayerView.Source = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(model.Video.Id, model.Video.Extension).ToString());
        }

        private void VideoPlayerView_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            if (VideoPlayerView.Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                IsVisible = false;
            }
            else if (VideoPlayerView.Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                IsVisible = true;
            }
        } 

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardPresentationView = null;

            VideoPlayerView.StatusUpdated -= VideoPlayerView_StatusUpdated;

            VideoPlayerView.Stop();

            VideoPlayerView.Source = null;

            VideoPlayerView.Dispose();
        }
    }
}