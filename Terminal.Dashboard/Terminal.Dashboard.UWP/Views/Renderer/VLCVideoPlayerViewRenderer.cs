using SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Extensions;

[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView), typeof(SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Views.Renderer.VLCVideoPlayerViewRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Views.Renderer
{
    public class VLCVideoPlayerViewRenderer : Xamarin.Forms.Platform.UWP.ViewRenderer<XFToolKit.Presentation.Views.Rendered.VideoPlayerView, VLC.MediaElement>
    {
        private bool disposed;

        public VLCVideoPlayerViewRenderer()
        {
            disposed = false;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<XFToolKit.Presentation.Views.Rendered.VideoPlayerView> eventArgs)
        {
            base.OnElementChanged(eventArgs);

            if (eventArgs.NewElement != null)
            {
                if (Control == null)
                {
                    var mediaElement = new VLC.MediaElement();

                    SetNativeControl(mediaElement);

                    mediaElement.MediaFailed += OnMediaElementSourceFailed;
                    mediaElement.CurrentStateChanged += OnMediaElementCurrentStateChanged;

                    Element.PlayRequested += Play_Requested;

                    SetAreTransportControlsEnabled();

                    SetAspectStrech();

                    SetAutoPlay();

                    SetSource();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || disposed || Element == null || (Element.AutoPlay && (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)) return;

            if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.StrechAspectProperty.PropertyName)
            {
                SetAspectStrech();
            }
            else if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.AutoPlayProperty.PropertyName)
            {
                SetAutoPlay();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.MediaFailed += OnMediaElementSourceFailed;
                Control.CurrentStateChanged += OnMediaElementCurrentStateChanged;

                Element.PlayRequested -= Play_Requested;

                Control.Stop();
            }

            Control?.Stop();

            base.Dispose(disposing);

            disposed = true;
        }

        private void Play_Requested(object sender, System.EventArgs eventArgs)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

            Control.Play();
        }

        private void OnMediaElementSourceFailed(object sender, VLC.MediaFailedRoutedEventArgs eventArgs)
        {
            Control?.Stop();
        }

        private void OnMediaElementCurrentStateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs eventArgs)
        {
            if (Control == null || disposed || Element == null || (Element.AutoPlay && (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)) return;

            var videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

            switch (Control.CurrentState)
            {
                case Windows.UI.Xaml.Media.MediaElementState.Playing:
                case Windows.UI.Xaml.Media.MediaElementState.Buffering:
                case Windows.UI.Xaml.Media.MediaElementState.Opening:
                    videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing;

                    break;

                case Windows.UI.Xaml.Media.MediaElementState.Closed:
                case Windows.UI.Xaml.Media.MediaElementState.Paused:
                case Windows.UI.Xaml.Media.MediaElementState.Stopped:
                    videoStatus = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

                    if (Element.AutoPlay)
                    {
                        Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;
                        Control.MediaFailed -= OnMediaElementSourceFailed;
                    }

                    break;
            }

            if (Element != null && (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status != videoStatus)
            {
                (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = videoStatus;
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
                if (Element.Source is XFToolKit.Presentation.Sources.Video.UriVideoSource)
                {
                    var uri = (Element.Source as XFToolKit.Presentation.Sources.Video.UriVideoSource).Uri;

                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        Control.MediaSource = VLC.MediaSource.CreateFromUri(uri);

                        hasSetSource = true;
                    }
                }
                else if (Element.Source is XFToolKit.Presentation.Sources.Video.FileVideoSource)
                {
                    var file = (Element.Source as XFToolKit.Presentation.Sources.Video.FileVideoSource).File;

                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        Control.MediaSource = VLC.MediaSource.CreateFromUri(file);

                        hasSetSource = true;
                    }
                }
                else if (Element.Source is XFToolKit.Presentation.Sources.Video.ResourceVideoSource)
                {
                    var path = (Element.Source as XFToolKit.Presentation.Sources.Video.ResourceVideoSource).Path;

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
                (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

                Control.Stop();
            }
        }

        private void SetAutoPlay()
        {
            if (Control == null || disposed) return;

            Control.AutoPlay = Element.AutoPlay;
        }
    }
}
