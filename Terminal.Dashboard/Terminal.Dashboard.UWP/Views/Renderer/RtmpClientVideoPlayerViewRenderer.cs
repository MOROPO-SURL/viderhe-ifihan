using System;
using Xamarin.Forms.Platform.UWP;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Views.Renderer
{
    public class RtmpClientVideoPlayerViewRenderer : ViewRenderer<Extend.Common.Templating.Presentation.Views.Rendered.UnattendedVideoPlayerView, Windows.UI.Xaml.Controls.MediaElement>
    {
        Mntone.Rtmp.Client.SimpleVideoClient rtmpVideoClient;

        protected override void OnElementChanged(ElementChangedEventArgs<Extend.Common.Templating.Presentation.Views.Rendered.UnattendedVideoPlayerView> eventArgs)
        {
            base.OnElementChanged(eventArgs);

            if (eventArgs.NewElement != null)
            {
                if (Control == null)
                {
                    rtmpVideoClient = new Mntone.Rtmp.Client.SimpleVideoClient();

                    rtmpVideoClient.Started += RtmpVideoClient_Started;

                    var mediaElement = new Windows.UI.Xaml.Controls.MediaElement();

                    SetNativeControl(mediaElement);

                    mediaElement.MediaEnded += MediaElement_MediaEnded; ;
                    mediaElement.MediaFailed += MediaElement_MediaFailed; ;
                    mediaElement.PartialMediaFailureDetected += MediaElement_PartialMediaFailureDetected; ;
                    mediaElement.CurrentStateChanged += MediaElement_CurrentStateChanged; ;
                }

                SetAreTransportControlsEnabled();

                SetSourceAsync();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (e.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.SourceProperty.PropertyName)
            {
                SetSourceAsync();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.MediaEnded -= MediaElement_MediaEnded;
                Control.MediaFailed -= MediaElement_MediaFailed;
                Control.PartialMediaFailureDetected -= MediaElement_PartialMediaFailureDetected;
                Control.CurrentStateChanged -= MediaElement_CurrentStateChanged;

                rtmpVideoClient.Started -= RtmpVideoClient_Started;

                rtmpVideoClient = null;
            }

            base.Dispose(disposing);
        }

        private void MediaElement_CurrentStateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            switch (Control.CurrentState)
            {
                case Windows.UI.Xaml.Media.MediaElementState.Playing:
                    (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing;

                    break;
            }
        }

        private void MediaElement_PartialMediaFailureDetected(Windows.UI.Xaml.Controls.MediaElement sender, Windows.UI.Xaml.Media.PartialMediaFailureDetectedEventArgs args)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;
        }

        private void MediaElement_MediaFailed(object sender, Windows.UI.Xaml.ExceptionRoutedEventArgs e)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;
        }

        private void MediaElement_MediaEnded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;
        }

        private void RtmpVideoClient_Started(object sender, Mntone.Rtmp.Client.SimpleVideoClientStartedEventArgs e)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, new Windows.UI.Core.DispatchedHandler(() =>
            {
                Control.SetMediaStreamSource(e.MediaStreamSource);
                Control.Play();
            })).AsTask();
        }

        private void OnStopRequested(object sender, EventArgs eventArgs)
        {
            Control.Stop();
        }

        private void SetAreTransportControlsEnabled()
        {
            Control.AreTransportControlsEnabled = Element.ShowControls;
        }

        private async void SetSourceAsync()
        {
            var hasSetSource = false;

            try
            {
                if (Element.Source is XFToolKit.Presentation.Sources.Video.UriVideoSource)
                {
                    var uri = (Element.Source as XFToolKit.Presentation.Sources.Video.UriVideoSource).Uri;

                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        await rtmpVideoClient.ConnectAsync(new Mntone.Rtmp.RtmpUri(uri));

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
            }
        }
    }
}
