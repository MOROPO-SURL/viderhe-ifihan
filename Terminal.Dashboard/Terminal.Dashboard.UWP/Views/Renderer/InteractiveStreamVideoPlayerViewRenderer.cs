using System;

[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Views.Rendered.InteracticeStreamVideoPlayerView), typeof(SmartSolucionesCuba.Videre.Terminal.Dashboard.UWP.Views.Renderer.InteractiveStreamVideoPlayerViewRenderer))]

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.UWP.Views.Renderer
{
    public class InteractiveStreamVideoPlayerViewRenderer : Xamarin.Forms.Platform.UWP.ViewRenderer<Viderhe.Extend.Common.Templating.Dashboard.Presentation.Views.Rendered.InteracticeStreamVideoPlayerView, Windows.UI.Xaml.Controls.MediaElement>
    {
        private Mntone.Rtmp.Client.SimpleVideoClient rtmpVideoClient;

        private bool willPlayOnAsyncLoadMediaSource;

        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<Viderhe.Extend.Common.Templating.Dashboard.Presentation.Views.Rendered.InteracticeStreamVideoPlayerView> eventArgs)
        {
            base.OnElementChanged(eventArgs);

            if (eventArgs.NewElement != null)
            {
                if (Control == null)
                {
                    rtmpVideoClient = new Mntone.Rtmp.Client.SimpleVideoClient();

                    rtmpVideoClient.Started += RtmpVideoClient_Started;
                    rtmpVideoClient.Stopped += RtmpVideoClient_Stopped;

                    SetNativeControl(new Windows.UI.Xaml.Controls.MediaElement());

                    Control.MediaEnded += MediaElement_MediaEnded;
                    Control.MediaFailed += MediaElement_MediaFailed;
                    Control.PartialMediaFailureDetected += MediaElement_PartialMediaFailureDetected;
                    Control.CurrentStateChanged += MediaElement_CurrentStateChanged;

                    Element.PlayRequested += Play_Requested;
                    Element.StopRequested += Stop_Requested;
                }

                if (Element.AutoPlay)
                {
                    willPlayOnAsyncLoadMediaSource = true;
                }

                SetAreTransportControlsEnabled();

                SetSourceAsync();
            }
        }

        private void RtmpVideoClient_Stopped(object sender, Mntone.Rtmp.Client.SimpleVideoClientStoppedEventArgs eventArgs)
        {
            if ((Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status != XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady) return;

            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

            if (Element.Repeat)
            {
                Play_Requested(sender, EventArgs.Empty);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs eventArgs)
        {
            base.OnElementPropertyChanged(sender, eventArgs);

            if (eventArgs.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (eventArgs.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.SourceProperty.PropertyName)
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
                rtmpVideoClient.Stopped -= RtmpVideoClient_Stopped;

                rtmpVideoClient = null;

                Element.PlayRequested -= Play_Requested;
                Element.StopRequested -= Stop_Requested;
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

            if (Element.Repeat)
            {
                Play_Requested(sender, EventArgs.Empty);
            }
        }

        private void MediaElement_MediaFailed(object sender, Windows.UI.Xaml.ExceptionRoutedEventArgs e)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

            if (Element.Repeat)
            {
                Play_Requested(sender, EventArgs.Empty);
            }
        }

        private void MediaElement_MediaEnded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended;

            if (Element.Repeat)
            {
                Play_Requested(sender, EventArgs.Empty);
            }
        }

        private void RtmpVideoClient_Started(object sender, Mntone.Rtmp.Client.SimpleVideoClientStartedEventArgs eventArgs)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, new Windows.UI.Core.DispatchedHandler(() =>
            {
                Control.SetMediaStreamSource(eventArgs.MediaStreamSource);

                if (!willPlayOnAsyncLoadMediaSource) return;

                Control.Play();

                willPlayOnAsyncLoadMediaSource = false;
            })).AsTask();
        }

        private void Stop_Requested(object sender, EventArgs eventArgs)
        {
            Control.Stop();
        }

        private void Play_Requested(object sender, EventArgs eventArgs)
        {
            if ((Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

                willPlayOnAsyncLoadMediaSource = true;

                SetSourceAsync();

                return;
            }

            Control.Play();
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
