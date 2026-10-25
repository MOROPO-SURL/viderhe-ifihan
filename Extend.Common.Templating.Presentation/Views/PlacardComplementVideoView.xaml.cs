using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Factories;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views
{
    public partial class PlacardComplementVideoView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        private Common.Presentation.Views.BasePlacardPresentationView placardPresentationView;

        public PlacardComplementVideoView(Common.Presentation.Views.BasePlacardPresentationView placardPresentationView, VideoComplementContextModel model)
        {
            InitializeComponent();

            switch (model.Position)
            {
                case VideoComplementPosition.TopLeft:
                case VideoComplementPosition.BottomLeft:
                    VideoPlayerViewLayout.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;

                    break;

                case VideoComplementPosition.TopRight:
                case VideoComplementPosition.BottomRight:
                default:
                    VideoPlayerViewLayout.HorizontalOptions = Xamarin.Forms.LayoutOptions.End;

                    break;
            }

            switch (model.Position)
            {
                case VideoComplementPosition.TopLeft:
                case VideoComplementPosition.TopRight:
                    VideoPlayerViewLayout.VerticalOptions = Xamarin.Forms.LayoutOptions.Start;

                    break;

                case VideoComplementPosition.BottomLeft:
                case VideoComplementPosition.BottomRight:
                default:
                    VideoPlayerViewLayout.VerticalOptions = Xamarin.Forms.LayoutOptions.End;

                    break;
            }

            IsVisible = false;

            VideoPlayerView.WidthRequest = VideoPlayerView.HeightRequest = placardPresentationView.Width * 0.15;

            this.placardPresentationView = placardPresentationView;

            VideoPlayerView.StatusUpdated += VideoPlayerView_StatusUpdated;

            VideoPlayerView.Source = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(VideoUriFactory.BuildVideoUri(model.Video.Id, model.Video.Extension).ToString());
        }

        private void VideoPlayerView_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            if (VideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                IsVisible = false;
            }
            else if (VideoPlayerView.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
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