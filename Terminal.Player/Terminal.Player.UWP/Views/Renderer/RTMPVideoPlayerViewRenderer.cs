using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views.Rendered;
using SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Extensions;
using System;

[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(CloudVideoPlayerView), typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Views.Renderer.RTMPVideoPlayerViewRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Views.Renderer
{
    public class RTMPVideoPlayerViewRenderer : Xamarin.Forms.Platform.UWP.ViewRenderer<CloudVideoPlayerView, Windows.UI.Xaml.Controls.MediaElement>
    {
        Mntone.Rtmp.Client.SimpleVideoClient rtmpVideoClient;

        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<CloudVideoPlayerView> eventArgs)
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

                    SetAreTransportControlsEnabled();

                    SetAspectStrech();

                    SetIsMuted();

                    if (Element.AutoPlay)
                    {
                        SetSourceAsync();
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs eventArgs)
        {
            base.OnElementPropertyChanged(sender, eventArgs);

            if (eventArgs.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.ShowControlsProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (eventArgs.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.StrechAspectProperty.PropertyName)
            {
                SetAspectStrech();
            }
            else if (eventArgs.PropertyName == XFToolKit.Presentation.Views.Rendered.VideoPlayerView.IsMutedProperty.PropertyName)
            {
                SetIsMuted();
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

                Control.Play();
            })).AsTask();
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

        private void Stop_Requested(object sender, EventArgs eventArgs)
        {
            Control.Stop();
        }

        private void Play_Requested(object sender, EventArgs eventArgs)
        {
            (Element as XFToolKit.Presentation.Views.Rendered.IVideoPlayerController).Status = XFToolKit.Presentation.Views.Rendered.VideoStatus.NotReady;

            SetSourceAsync();
        }

        private void SetAspectStrech()
        {
            Control.Stretch = Element.StrechAspect.ToUWP();
        }

        private void SetIsMuted()
        {
            Control.IsMuted = Element.IsMuted;
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