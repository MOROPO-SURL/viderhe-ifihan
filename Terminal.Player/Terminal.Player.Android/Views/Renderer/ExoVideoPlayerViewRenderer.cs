using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Upstream;
using Java.Lang;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView), typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer.ExoVideoPlayerViewRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer
{
    public class ExoVideoPlayerViewRenderer : ViewRenderer<XFToolKit.Presentation.Views.Rendered.VideoPlayerView, PlayerView>, IPlayerEventListener
    {
        public ExoVideoPlayerViewRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<XFToolKit.Presentation.Views.Rendered.VideoPlayerView> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    var trackSelector = new Com.Google.Android.Exoplayer2.Trackselection.DefaultTrackSelector(Context);

                    trackSelector.SetParameters(trackSelector.BuildUponParameters().SetMaxVideoSizeSd());

                    var renderersFactory = new DefaultRenderersFactory(Context);

                    var playerBuilder = new SimpleExoPlayer.Builder(Context, renderersFactory).SetTrackSelector(trackSelector);

                    var playerView = new PlayerView(Context)
                    {
                        Player = playerBuilder.Build(),
                        ControllerAutoShow = false,
                        UseController = false,
                        ControllerHideOnTouch = false,

                    };

                    playerView.Player.AddListener(this);

                    SetNativeControl(playerView);
                }

                SetAreTransportControlsEnabled();

                SetSource();

                SetAutoPlay();

                args.NewElement.StopRequested += OnStopRequested;
            }

            if (args.OldElement != null)
            {
                args.OldElement.StopRequested -= OnStopRequested;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.Player.RemoveListener(this);

                Control.Player.Release();

                Control.Player.Dispose();

                Control.Player = null;
            }

            base.Dispose(disposing);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (args.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.AutoPlayProperty.PropertyName)
            {
                SetAutoPlay();
            }
        }

        private void SetAreTransportControlsEnabled()
        {
            if (Element.ShowControls)
            {
                Control.ShowController();
            }
            else
            {
                Control.HideController();
            }
        }

        private void SetSource()
        {
            var hasSetSource = false;

            var mediaSourceFactory = new Com.Google.Android.Exoplayer2.Source.ProgressiveMediaSource.Factory(new DefaultDataSourceFactory(Context, "Viderhe ExoPlayer"));

            if (Element.Source is XFToolKit.Presentation.Sources.Video.UriVideoSource)
            {
                var uri = (Element.Source as XFToolKit.Presentation.Sources.Video.UriVideoSource).Uri;

                if (!string.IsNullOrWhiteSpace(uri))
                {
                    (Control.Player as SimpleExoPlayer).Prepare(mediaSourceFactory.CreateMediaSource(Android.Net.Uri.Parse(uri)));

                    hasSetSource = true;
                }
            }
            else if (Element.Source is XFToolKit.Presentation.Sources.Video.FileVideoSource)
            {
                var filename = (Element.Source as XFToolKit.Presentation.Sources.Video.FileVideoSource).File;

                if (!string.IsNullOrWhiteSpace(filename))
                {
                    (Control.Player as SimpleExoPlayer).Prepare(mediaSourceFactory.CreateMediaSource(Android.Net.Uri.Parse(filename)));

                    hasSetSource = true;
                }
            }
            else if (Element.Source is XFToolKit.Presentation.Sources.Video.ResourceVideoSource)
            {
                var package = Context.PackageName;

                var path = (Element.Source as XFToolKit.Presentation.Sources.Video.ResourceVideoSource).Path;

                if (!string.IsNullOrWhiteSpace(path))
                {
                    var filename = System.IO.Path.GetFileNameWithoutExtension(path).ToLowerInvariant();
                    var uri = "android.resource://" + package + "/raw/" + filename;

                    (Control.Player as SimpleExoPlayer).Prepare(mediaSourceFactory.CreateMediaSource(Android.Net.Uri.Parse(uri)));

                    hasSetSource = true;
                }
            }

            if (hasSetSource && Element.AutoPlay)
            {
                Control.Player.PlayWhenReady = true;
            }
        }

        private void OnStopRequested(object sender, System.EventArgs args)
        {
            Control.Player.Stop();
        }

        private void SetAutoPlay()
        {
            Control.Player.PlayWhenReady = Element.AutoPlay;
        }

        public void OnLoadingChanged(bool p0)
        {
            //throw new NotImplementedException();
        }

        public void OnPlaybackParametersChanged(PlaybackParameters p0)
        {
            //throw new NotImplementedException();
        }

        public void OnPlayerError(ExoPlaybackException p0)
        {
            Control.Player.Stop();
        }

        public void OnPlayerStateChanged(bool playWhenReady, int playbackState)
        {
            var videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

            switch (playbackState)
            {
                case IPlayer.StateEnded:
                    videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.Paused;

                    break;

                case IPlayer.StateReady:
                    videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing;

                    break;
            }

            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = videoStatus;
        }

        public void OnPositionDiscontinuity()
        {
            //throw new NotImplementedException();
        }

        public void OnRepeatModeChanged(int p0)
        {
            //throw new NotImplementedException();
        }

        public void OnTimelineChanged(Timeline p0, Java.Lang.Object p1)
        {
            //throw new NotImplementedException();
        }

        public void OnTracksChanged(Com.Google.Android.Exoplayer2.Source.TrackGroupArray p0, Com.Google.Android.Exoplayer2.Trackselection.TrackSelectionArray p1)
        {
            //throw new NotImplementedException();
        }

        public void OnPositionDiscontinuity(int p0)
        {
            //throw new System.NotImplementedException();
        }

        public void OnSeekProcessed()
        {
            //throw new System.NotImplementedException();
        }

        public void OnShuffleModeEnabledChanged(bool p0)
        {
            //throw new System.NotImplementedException();
        }

        public void OnTimelineChanged(Timeline p0, Object p1, int p2)
        {
            //throw new System.NotImplementedException();
        }
    }
}