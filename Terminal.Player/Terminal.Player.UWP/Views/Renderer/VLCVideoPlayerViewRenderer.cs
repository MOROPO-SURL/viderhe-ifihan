using MOROPO.VIDERHE.Terminal.Player.UWP.Extensions;

[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView), typeof(MOROPO.VIDERHE.Terminal.Player.UWP.Views.Renderer.VLCVideoPlayerViewRenderer))]

namespace MOROPO.VIDERHE.Terminal.Player.UWP.Views.Renderer
{
    public class VLCVideoPlayerViewRenderer : Xamarin.Forms.Platform.UWP.ViewRenderer<SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView, VLC.MediaElement>
    {
        private bool disposed;

        public VLCVideoPlayerViewRenderer()
        {
            disposed = false;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView> eventArgs)
        {
            base.OnElementChanged(eventArgs);

            if (eventArgs.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new VLC.MediaElement());

                    Control.MediaFailed += OnMediaElementSourceFailed;
                    Control.CurrentStateChanged += OnMediaElementCurrentStateChanged;

                    SetAreTransportControlsEnabled();

                    SetAspectStrech();

                    SetAutoPlay();

                    SetSource();

                    Element.ReleaseRequested += Element_ReleaseRequested;
                }
            }
        }

        private void Element_ReleaseRequested(object sender, System.EventArgs e)
        {
            Dispose();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || disposed || Element == null || (Element.AutoPlay && (Element as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)) return;

            if (e.PropertyName == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (e.PropertyName == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView.StrechAspectProperty.PropertyName)
            {
                SetAspectStrech();
            }
            else if (e.PropertyName == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (e.PropertyName == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView.AutoPlayProperty.PropertyName)
            {
                SetAutoPlay();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed) return;

            Element.ReleaseRequested -= Element_ReleaseRequested;

            Control.MediaFailed -= OnMediaElementSourceFailed;
            Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;

            Control.Stop();

            Control.Source = null;
            Control.MediaSource = null;

            SetNativeControl(null);

            base.Dispose(disposing);

            disposed = true;
        }

        private void OnMediaElementSourceFailed(object sender, VLC.MediaFailedRoutedEventArgs eventArgs)
        {
            Control?.Stop();
        }

        private void OnMediaElementCurrentStateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs eventArgs)
        {
            if (Control == null || disposed || Element == null || (Element.AutoPlay && (Element as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)) return;

            var videoStatus = SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

            switch (Control.CurrentState)
            {
                case Windows.UI.Xaml.Media.MediaElementState.Playing:
                case Windows.UI.Xaml.Media.MediaElementState.Buffering:
                case Windows.UI.Xaml.Media.MediaElementState.Opening:
                    videoStatus = SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing;

                    break;

                case Windows.UI.Xaml.Media.MediaElementState.Closed:
                case Windows.UI.Xaml.Media.MediaElementState.Paused:
                case Windows.UI.Xaml.Media.MediaElementState.Stopped:
                    videoStatus = SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

                    if (Element.AutoPlay)
                    {
                        Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;
                        Control.MediaFailed -= OnMediaElementSourceFailed;
                    }

                    break;
            }

            if (Element != null && (Element as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status != videoStatus)
            {
                (Element as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = videoStatus;
            }
        }

        private void SetAreTransportControlsEnabled()
        {
            if (Control == null || disposed) return;

            Control.AreTransportControlsEnabled = Element.ShowControls;
        }

        private void SetAspectStrech()
        {
            Control.Stretch = Element.StrechAspect.ToUWP();
        }

        private void SetSource()
        {
            if (Control == null || disposed) return;

            var hasSetSource = false;

            try
            {
                if (Element.Source is SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.UriVideoSource)
                {
                    var uri = (Element.Source as SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.UriVideoSource).Uri;

                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        Control.MediaSource = VLC.MediaSource.CreateFromUri(uri);

                        hasSetSource = true;
                    }
                }
                else if (Element.Source is SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.FileVideoSource)
                {
                    var file = (Element.Source as SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.FileVideoSource).File;

                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        Control.MediaSource = VLC.MediaSource.CreateFromUri(file);

                        hasSetSource = true;
                    }
                }
                else if (Element.Source is SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.ResourceVideoSource)
                {
                    var path = (Element.Source as SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.ResourceVideoSource).Path;

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        Control.MediaSource = VLC.MediaSource.CreateFromUri(path);

                        hasSetSource = true;
                    }
                }
            }
            catch
            {
            }

            if (!hasSetSource)
            {
                (Element as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;
            }
        }

        private void SetAutoPlay()
        {
            if (Control == null || disposed) return;

            Control.AutoPlay = Element.AutoPlay;
        }
    }
}
